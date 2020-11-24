import { generalRequest, getRequest } from "../../utilities";
import { url, port } from "./server";
import { createLdapEntry, searchUserLdap } from "../../ldap/ldap";
//Añadir la url correspondiente a su microservicio
const URL = `http://${url}:${port}`;

const resolvers = {
  //Añadir las definiciones por url de las request
  Mutation: {
    register: (_, { userToRegister }) => crear_usuario(userToRegister),
    login: (_, { username, password }) =>
      generalRequest(`${URL}/authenticate`, "POST", { username, password }),
  },
};

async function crear_usuario(userToRegister) {
  await createLdapEntry(userToRegister.username, userToRegister.password);
  return generalRequest(`${URL}/register`, "POST", userToRegister);
}

async function revisar_usuario(username, password) {
  return await searchUserLdap(username, password).then((res) => {
    return generalRequest(`${URL}/users/${username}/${password}`, "GET").then(
      (objeto) => {
        if (res && objeto.username != null) {
          return objeto;
        }
        return null;
      }
    );
  });
}

export default resolvers;
