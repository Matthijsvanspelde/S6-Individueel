<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
import NavBar from "@/components/NavBar.vue";

</script>

<template>
<NavBar/>
<div class="container">
  
  <RouterView />  
</div>
  
</template>

<style>
@import "@/assets/base.css";

li a {
  color: rgba(0,0,0,.9);
  text-decoration: none;
}

li a:hover {
  color: rgba(0,0,0,.9);
}

body {
  background-color: rgb(238, 238, 238) !important;
}

nav {
  margin-bottom: 14px;
}
</style>
