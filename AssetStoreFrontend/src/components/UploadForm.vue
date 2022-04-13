<template>

    <form ref="form" v-on:submit.prevent="onSubmit" enctype="multipart/form-data" class = 'card p-3 bg-light'>
        <h3>Upload new asset</h3>
        <label>Username</label>
        <div class="input-group mb-3">
            <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" v-model="assetData.name">
        </div>
        <label>description</label>
        <div class="input-group">
            <textarea class="form-control" aria-label="With textarea" v-model="assetData.description"></textarea>
        </div>

        <br/>
        
        <label>File</label>
        <input type="file" @change="onFileChange($event)"/><br/>
        <button type="submit" class="btn btn-primary">Create</button>
    </form>

</template>

<script>

export default {
    name: "AssetTile",
    data () {
        return {
            formData: new FormData(),
            assetData: {
                name: '', 
                description: '', 
                file: null
            }
        }
    },
    methods: {
    getAssets: function () {
        this.formData.append('Name', this.assetData.name);
        this.formData.append('Description', this.assetData.description);
        this.formData.append('File', this.assetData.file);
        this.axios
        .post('https://localhost:5001/api/asset', this.formData)
    },

    onFileChange(e) {
        this.assetData.file = e.target.files[0];
    },

    onSubmit () {

        this.getAssets();
    }
  },
}
</script>

<style scoped>
</style>