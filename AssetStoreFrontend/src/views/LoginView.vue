<template>
<div class="d-flex flex-column justify-content-center">
  <div class="p-2"><LoginForm/></div>
</div>
  
</template>

<script>
import LoginForm from "@/components/LoginForm.vue";
export default {
  name: "LoginView",
  components: {
    LoginForm
  }
}
</script>

<style>
.container {
  max-width: 500px !important;
}
</style>
