<template>
  <div class="divlogin">
    <div class="container">
      <div class="divcont">
        <img class="logo" alt="Dayscool logo" src="../assets/Logo512px.svg" />
        <h3>Crear una cuenta de Dayscool</h3>
        <form>
          <div class="line-form">
            <div class="cell-form">
              <label>Nombre completo</label>
              <input
                v-model="form.nombreC"
                class="form-input"
                id="nombreUsuario"
                required
              />
            </div>
            <div class="cell-form">
              <label>Nombre de usuario</label>
              <input
                v-model="form.nombreU"
                class="form-input"
                id="nombreU"
                required
              />
            </div>
          </div>
          <div class="line-form">
            <div class="cell-form">
              <label>Correo electronico</label>
              <input
                type="email"
                v-model="form.email"
                class="form-input"
                id="email"
                required
              />
            </div>
            <div class="cell-form">
              <label>Fecha de nacimiento</label>
              <input
                type="date"
                v-model="form.fecha"
                class="form-input"
                id="fechaN"
                required
              />
            </div>
          </div>
          <div class="line-form">
            <div class="cell-form">
              <label>Carrera</label>
              <input
                type="text"
                v-model="form.carrera"
                class="form-input"
                id="carrera"
                required
              />
            </div>
            <div class="cell-form">
              <label>Rol</label>
              <select name="rol" id="rol" v-model="form.rol">
                <option>Profesor</option>
                <option>Estudiante</option>
              </select>
            </div>
          </div>
          <label>Contraseña</label>
          <input
            type="password"
            v-model="form.password"
            class="form-input"
            id="password"
            placeholder="Contraseña"
          />
          <label>Confirmar Contraseña</label>
          <input
            type="password"
            v-model="form.cpassword"
            class="form-input"
            id="cpassword"
            placeholder="Confirmar Contraseña"
          />
        </form>
        <button type="submit" class="button button1" @click="sendNewUser()">
          Registrarme
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "signup",
  data() {
    return {
      errors: [],
      form: {
        nombreC: "",
        nombreU: "",
        email: "",
        fecha: "",
        rol: "",
        carrera: "",
        password: "",
        cpassword: "",
      },
    };
  },
  methods: {
    checkUser: function(e) {
      if (
        this.form.nombreC &&
        this.form.nombreU &&
        this.form.email &&
        this.form.fecha &&
        this.form.carrera &&
        this.form.password &&
        this.form.cpassword
      ) {
        return true;
      } else {
        this.errors.push("datos incompletos");
      }
      e.preventDefault();
      console.log(this.errors);
    },
    sendNewUser() {
      if (this.form.username != "" && this.form.password != "") {
        axios
          .post(this.$store.state.backURL, {
            query: `
            mutation createUser2($user2: User2Input!){
              createUser2(user2: $user2) {
                id
                username
                role
              }
            }`,
            variables: {
              user2: {
                username: this.form.nombreU,
                mail: this.form.email,
                birthDate: this.form.fecha,
                career: this.form.carrera,
                role: this.form.rol,
                name: this.form.nombreC,
                password: this.form.password,
              },
            },
          })
          .then((response) => {
            console.log(response.data.data);
            alert("Usuario registrado");
          })
          .catch((err) => {
            console.log(err);
            alert("Nombre de usuario ya registrado");
          });
      } else {
        alert("Datos incompletos");
      }
    },
  },
};
</script>

<style scoped lang="scss">
body {
  background: #4191e0;
  display: flex;
}
form {
  width: 100%;
}
input {
  max-width: 25vw;
}
.container {
  width: 100%;
  padding: 0%;
  text-align: center;
}
.divcont {
  width: 50vw;
  background: white;
  margin: 30px;
  padding: 2%;
  border-radius: 10px;
  display: inline-block;
  max-height: 85vh;
}
.input1 {
  width: 50%;
}
.line-form {
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  margin: 5px;
}
.cell-form {
  width: 40%;
}
</style>
