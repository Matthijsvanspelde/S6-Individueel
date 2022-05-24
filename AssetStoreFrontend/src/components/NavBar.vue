<template>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">
      <BIconDpadFill style="color: #326ce5; transform: scale(1.5); margin-right: 8px;"/>
      Asset Store
    </a>
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
  <form class="form-inline">
    <RouterLink class="btn btn-primary my-2 my-sm-0" tag="button" to="/login">Login</RouterLink>
  </form>
</nav>
</template>

<script>
export default {
    name: "NavBar",
    data () {
        return {

        }
    },
}
</script>

<style scoped>
    .navbar-brand {
        margin-left: 16px;
    }

    .form-inline {
        margin-right: 16px
    }
</style>