<template>
<div class="card">
    <h5 class="card-header">
            Create an account on the Asset Store
    </h5>
    <div class="card-body">
        <form ref="form" v-on:submit.prevent="onSubmit" enctype="multipart/form-data">
        
        <label>Username</label>
        <div class="input-group mb-3">
            <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" v-model="assetData.username">
        </div>
        <label>Your profile page will be:</label><br/>
        <div class="alert alert-primary" role="alert">
            https://assetstore.com/{{assetData.username}}
        </div>
        <label>Password</label>
        <div class="input-group">
            <input type="password" class="form-control" aria-label="Password" aria-describedby="basic-addon1" v-model="assetData.password">
        </div>
        <br/>
        <label>Confirm Password</label>
        <div class="input-group">
            <input type="password" class="form-control" aria-label="Password" aria-describedby="basic-addon1">
        </div>
        <br/>
        <label>Email address</label>
        <div class="input-group">
            <input type="text" class="form-control" aria-label="Password" aria-describedby="basic-addon1" v-model="assetData.emailaddress" placeholder="name@example.com">
        </div>
        <br/>
        <div class="form-check">
            <input type="checkbox" class="form-check-input" id="exampleCheck1" checked>
            <label class="form-check-label" for="exampleCheck1" >Sign me up for the newsletter</label>
        </div><br/>
        <div class="form-check">
            <input type="checkbox" class="form-check-input" id="exampleCheck1">
            <label class="form-check-label" for="exampleCheck1">I accept the <a href="">terms of service</a></label>
        </div><br/>
        <button type="submit" class="btn btn-primary w-100">Register</button>
        </form>

    </div>
    <div class="card-footer text-muted">
        Already have an account? Log in here
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
                emailaddress: '',
                username: '', 
                password: '', 
            }
        }
    },
    methods: {
    onSubmit () {
        this.formData.append('Username', this.assetData.username);
        this.formData.append('Password', this.assetData.password);
        this.formData.append('Email', this.assetData.emailaddress);
        this.axios
        .post('https://localhost:5003/api/authentication/register', this.formData)
        .then(result => {
            this.$router.push('login') 
        })
    },
  },
}
</script>

<style scoped>
</style>