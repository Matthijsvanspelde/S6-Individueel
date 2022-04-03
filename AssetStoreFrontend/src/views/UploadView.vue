<template>
  <div class="about">
    <UploadForm/>
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
</style>
