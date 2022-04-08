<template>
    <form ref="form" v-on:submit.prevent="onSubmit" enctype="multipart/form-data">
        <h1>Upload</h1>
        <label>name</label><br/>
        <input type="text" class="inputField" v-model="assetData.name"/>
        <br/>
        <label>description</label><br/>
        <textarea class="inputField" v-model="assetData.description"></textarea>
        <br/>
        <label>File</label><br/>
        <input type="file" @change="onFileChange($event)"/>
        <input type="submit" value="create"/>
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
.inputField {
    padding: 6px;
    border: none;
    border-radius: 6px;
    box-shadow: rgba(99, 99, 99, 0.1) 0px 2px 8px 0px;
    font-family: Arial, Helvetica, sans-serif;
}
</style>