<template>
  <NavBar v-if="this.$store.getters.isLoggedIn" />
  <router-view />
</template>

<script>
import NavBar from "@/components/NavBar.vue";
export default {
  components: {
    NavBar,
  },
};
</script>

<style lang="scss">
@import url("https://fonts.googleapis.com/css2?family=Montserrat+Alternates:wght@100;200;300;400;500;600;700;800;900&display=swap");
body {
  margin: 0;
  padding: 0;
}
* {
  font-family: "Montserrat Alternates";
}
input,
select {
  width: 100%;
  padding: 12px 20px;
  margin: 10px 0;
  box-sizing: border-box;
  border-radius: 4px;
  border: 2px solid #ccc;
  font-family: "Montserrat Alternates";
}
h3 {
  font-size: 1.8vw;
  font-weight: 400;
}
form {
  text-align: left;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: center;
  width: 80%;
}
button {
  background-color: #4c87af;
  border: none;
  border-radius: 4px;
  color: white;
  padding: 12px 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 6px 16px;
  transition-duration: 0.4s;
  cursor: pointer;
  font-weight: 600;
}
#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
.logo {
  width: 5vw;
  height: 5vw;
  max-width: 200px;
  max-height: 200px;
}
.button1 {
  background-color: white;
  color: black;
  border: 1px solid #4191e0;
}
.button1:hover {
  background-color: #4191e0;
  color: white;
}
.divlogin {
  background-image: url("assets/fondo-login.jpg");
  width: 100%;
  height: 100vh;
  padding: 0%;
  display: flex;
  align-content: center;
  align-items: center;
}
</style>
