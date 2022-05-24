<template>
<div class="card">
    <h5 class="card-header">
            Log in to your Asset Store account
    </h5>
    <div class="card-body">
        <form ref="form" v-on:submit.prevent="onSubmit" enctype="multipart/form-data">
        
        <label>Username</label>
        <div class="input-group mb-3">
            <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" v-model="assetData.username">
        </div>
        <label>Password</label>
        <div class="input-group">
            <input type="password" class="form-control" aria-label="Password" aria-describedby="basic-addon1" v-model="assetData.password">
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
            formData: new FormData(),
            assetData: {
                username: '', 
                password: '', 
            }
        }
    },
    methods: {
    onSubmit () {
        this.formData.append('Username', this.assetData.username);
        this.formData.append('Password', this.assetData.password);
        this.axios
        .post('https://localhost:5003/api/authentication/login', this.formData)
        .then(result => {
            console.log(result.data.token);
            localStorage.setItem("token", result.data.token);
            localStorage.setItem("expiration", result.data.expiration);
            this.props.history.push('/');
        })
    },
  },
}
</script>

<style scoped>

</style>