<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";

</script>

<template>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="#">Asset Store</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link"><RouterLink to="/">Home</RouterLink></a>
      </li>
      <li class="nav-item">
        <a class="nav-link"><RouterLink to="/upload">Upload</RouterLink></a>
      </li>
    </ul>
  </div>
</nav>
  <RouterView />
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
</style>
