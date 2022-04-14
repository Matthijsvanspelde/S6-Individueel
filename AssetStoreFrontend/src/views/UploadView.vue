<template>
<div class="d-flex flex-column justify-content-center">
  <div class="p-2"><UploadForm/></div>
</div>
  
</template>

<script>
import UploadForm from "@/components/UploadForm.vue";
export default {
  name: "HomeView",
  components: {
    UploadForm
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


.container {
  max-width: 900px !important;
}
</style>
