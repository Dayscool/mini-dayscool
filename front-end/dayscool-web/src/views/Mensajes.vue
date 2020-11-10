<template>
  <div class="mensajes">
    <h1>Chats</h1>
    <SendMessage />
  </div>
</template>
<script>
import SendMessage from "@/components/SendMessage.vue";

export default {
  name: "Home",
  components: {
    SendMessage
  }
};
</script>
