// Definir el objeto que van a usar y los campos necesarios para crearlo
export const authenticationTypeDef = `
  type UserAuth {
      id: Int!
      username: String!
      mail: String!
      birthDate: String!
      career: String!
      role: String!
      name: String!
  }
  type Token {
    token: String
  }
  input UserAuthInput {
      username: String!
      password: String!
      mail: String!
      birthDate: String!
      career: String!
      role: String!
      name: String!
  }`;

//Definir las consultas del objeto (solo GET)
//Definir las mutaciones (POST PUT Y DELETE)
export const authenticationMutations = `
  register(userToRegister: UserAuthInput!): UserAuth!
  login(username: String!, password: String!): Token!
`;
