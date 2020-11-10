<template>
  <div class="about">
    <h1>This is an about page</h1>
    <CreateActivity/>
    
  </div>
</template>
<script>

import CreateActivity from "@/components/CreateActivity.vue";

export default {
  name: "Home",
  components: {
    CreateActivity
  }
};
</script>