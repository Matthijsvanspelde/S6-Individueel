<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";

</script>

<template>
  <header>
    <nav>
      <ul>
        <li><RouterLink to="/">Home</RouterLink></li>
        <li><RouterLink to="/upload">Upload</RouterLink></li>
      </ul>
    </nav>
  </header>

  <RouterView />
</template>

<style>
@import "@/assets/base.css";

body {
  background-color: #F4F4F4;
}

#app {
  max-width: 1280px;
  margin: 0 auto;
  padding: 2rem;
  font-weight: normal;
}

ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  overflow: hidden;
  background-color: #ffffff;
  position: fixed;
  left: 0;
  top: 0;
  width: 100vw;
  box-shadow: rgba(99, 99, 99, 0.1) 0px 2px 8px 0px;
}

li {
  float: left;
}

li a {
  display: block;
  color: #333;
  text-align: center;
  padding: 12px 14px;
  text-decoration: none;
}

li a:hover:not(.active) {
  background-color: #ddd;
}

li a.active {
  color: white;
  background-color: #04AA6D;
}
</style>
