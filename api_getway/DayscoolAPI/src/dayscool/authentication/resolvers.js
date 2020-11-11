import { generalRequest, getRequest } from "../../utilities";
import { url, port, entryPoint } from "./server";
import {createLdapEntry, searchUserLdap} from "../../ldap/ldap"
//Añadir la url correspondiente a su microservicio
const URL = `http://${url}:${port}/${entryPoint}`;

const resolvers = {
  //Añadir las definiciones por url de las request
  Query: {
    getUserC: (_, { username, password }) =>
      revisar_usuario(username, password)
  },
  Mutation: {
    createUser2: (_, { user2 }) =>
     crear_usuario(user2),
  },
};

async function crear_usuario(user2) {
  await createLdapEntry(user2.username, user2.password);
  return generalRequest(`${URL}/users`, "POST", user2)
}

async function revisar_usuario(username, password) {
  return await searchUserLdap(username, password).then((res) => {
    return generalRequest(`${URL}/users/${username}/${password}`, "GET").then((objeto) => {
      if(res && objeto.username != null) {
        return objeto;
      }
      return null;
    })
  })
}

export default resolvers;
