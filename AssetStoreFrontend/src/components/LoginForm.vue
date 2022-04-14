<template>
<div class="card">
    <h5 class="card-header">
            Log in to your Asset Store account
    </h5>
    <div class="card-body">
        <form ref="form" v-on:submit.prevent="onSubmit" enctype="multipart/form-data">
        
        <label>Username</label>
        <div class="input-group mb-3">
            <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1">
        </div>
        <label>Password</label>
        <div class="input-group">
            <input type="password" class="form-control" aria-label="Password" aria-describedby="basic-addon1">
        </div>
        <br/>
        <button type="submit" class="btn btn-primary w-100">Login</button>
        </form>

    </div>
    <div class="card-footer text-muted">
        New to the Asset Store? Sign up here
    </div>
</div>


</template>

<script>

export default {
    name: "LoginForm",
    data () {
        return {

        }
    },
    methods: {
    onSubmit () {

    }
  },
}
</script>

<style scoped>

</style>