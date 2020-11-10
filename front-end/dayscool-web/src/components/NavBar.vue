<template>
  <div id="nav-container">
    <router-link to="/">
      <img class="icon" src="../assets/Logo512px.svg" alt="logo"
    /></router-link>
    <div>
      <span id="page-title">{{ $store.getters.getCurrentView }}</span>
    </div>
    <div id="user-info">
      <div id="icon-container">
        <img
          class="icon-small"
          src="../assets/notification.svg"
          alt="notification"
        />
        <img
          class="icon-small"
          src="../assets/envelope_close.svg"
          alt="message"
        />
      </div>
      <div>
        <span>{{ $store.getters.returnUser.role }}</span>
        <span>{{ $store.getters.returnUser.name }}</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "NavBar",
};
</script>

<style lang="scss" scoped>
div {
  border: 1px solid black;
}
.icon {
  width: 3vw;
  max-width: 100px;
  margin: 10px 50px;
}
.icon-small {
  width: 3vw;
  max-width: 100px;
}
#nav-container {
  border: 1px solid #4c87af;
  width: 100vw;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
#page-title {
  width: 60vw;
  text-decoration: underline;
  color: #4191e0;
  font-weight: 600;
  font-size: 2vw;
  margin-top: 20px;
}
#user-info {
  display: flex;
  flex-direction: column;
  justify-content: space-around;
}
#icon-container {
  width: 10vw;
}
</style>
