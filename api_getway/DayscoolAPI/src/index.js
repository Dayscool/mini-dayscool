import Koa from "koa";
import KoaRouter from "koa-router";
import koaLogger from "koa-logger";
import koaBody from "koa-bodyparser";
import koaCors from "@koa/cors";

import { graphiqlKoa, graphqlKoa } from "apollo-server-koa";
import graphQLSchema from "./graphQLSchema";

import { formatErr } from "./utilities";
const request = require("request-promise");
const app = new Koa();
const router = new KoaRouter();
const PORT = process.env.PORT || 5000;
const authURL = "http://172.17.0.1:10500/authorize";
app.use(koaLogger());
app.use(koaCors());
app.use(koaBody());

// read token from header
app.use(async (ctx, next) => {
  if (ctx.header.authorization) {
    const response = await request({
      url: authURL,
      method: "POST",
      headers: {
        Authorization: ctx.header.authorization,
      },
      simple: false,
      resolveWithFullResponse: true,
    });
    if (response.statusCode == "200") {
      await next();
    } else {
      ctx.status = 401;
    }
  } else if (
    JSON.stringify(ctx.request.body).includes("login") ||
    JSON.stringify(ctx.request.body).includes("register") ||
    ctx.url.includes("graphiql")
  ) {
    await next();
  } else {
    ctx.status = 401;
  }
});

// GraphQL
const graphql = graphqlKoa((ctx) => ({
  schema: graphQLSchema,
  context: { token: ctx.state.token },
  formatError: formatErr,
}));
router.post("/graphql", koaBody(), graphql);

router.get("/graphql", graphql);

// test route
router.get("/graphiql", graphiqlKoa({ endpointURL: "/graphql" }));

app.use(router.routes());
app.use(router.allowedMethods());

app.listen(PORT, () => console.log(`Server running on port ${PORT}`));
