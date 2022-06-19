<template>
<div v-if="this.isLoggedIn" class="d-flex flex-column justify-content-center ucontainer">
  <div class="p-2"><UploadForm/></div>
</div>
  
</template>

<script>
import UploadForm from "@/components/UploadForm.vue";
export default {
  name: "HomeView",
  components: {
    UploadForm
  },
  computed: {
    isLoggedIn() {
      return !!window.localStorage.getItem('token')
    }
  }
}
</script>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 50vh;
    display: flex;
    align-items: center;
  }
}


.ucontainer {
  left: 27%;
  margin-top: 80px;
  max-width: 900px;
}
</style>
