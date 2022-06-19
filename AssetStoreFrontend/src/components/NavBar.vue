<template>
<nav class="navbar fixed-top navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">
      <BIconDpadFill style="color: #326ce5; transform: scale(1.2); margin-right: 8px; margin-top: -4px;"/>
      Asset Store
    </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link"><RouterLink to="/">Browse</RouterLink></a>
      </li>
      <li class="nav-item">
        <a class="nav-link"><RouterLink to="/upload" v-if="this.isLoggedIn">Upload</RouterLink></a>
      </li>
    </ul>
  </div>
  <div class="username" v-if="this.isLoggedIn">Matthijs1999</div>
  <form class="form-inline">
    <RouterLink class="btn btn-primary my-2 my-sm-0" tag="button" to="/login" v-if="!this.isLoggedIn">Log in</RouterLink>
    <RouterLink class="btn btn-link my-2 my-sm-0" tag="button" to="/register" v-if="!this.isLoggedIn">Register</RouterLink>
    <a v-on:click="onSubmit()" href="#" class="btn btn-primary" v-if="this.isLoggedIn">Log out</a>
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
    methods: {
      onSubmit () {
          localStorage.clear();
      },
  },
  computed: {
    isLoggedIn() {
      return !!window.localStorage.getItem('token')
    }
  } 
}
</script>

<style scoped>
  nav {
    box-shadow: rgba(0, 0, 0, 0.05) 0px 1px 0px;
  }

  .navbar-brand {
      margin-left: 16px;
  }

  .form-inline {
      margin-right: 16px
  }

  .btn-link{
    color: black;
    text-decoration: none;
  }

  .username {
    margin: 0 16px;
  }
</style>