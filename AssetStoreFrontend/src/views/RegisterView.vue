<template>
<div class="d-flex flex-column justify-content-center">
  <div class="p-2 container"><RegisterForm/></div>
</div>
  
</template>

<script>
import RegisterForm from "@/components/RegisterForm.vue";
export default {
  name: "RegisterrView",
  components: {
    RegisterForm
  }
}
</script>

<style>
.container {
  margin-top: 80px;
  max-width: 500px;
}
</style>