<template>
<div class="alert alert-success" role="alert" v-if="msg != ''">
    {{this.msg}}
</div>
<div class="card">
    <h5 class="card-header">
            Create new asset
    </h5>
    <div class="card-body">
        <form ref="form" v-on:submit.prevent="onSubmit" enctype="multipart/form-data">
        
        <label>Title</label>
        <div class="input-group mb-3">
            <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" v-model="assetData.name">
        </div>

        <label>Cover Image</label>
        <input class="form-control" type="file" @change="pickFile" accept="image/*">
        <output>
            <img :src="previewUrl" v-if="previewUrl">
            <p v-else>Cover image</p>
        </output>

        <br/>
        <label>Description</label>
        <div class="input-group">
            <textarea class="form-control" aria-label="With textarea" v-model="assetData.description" rows="12"></textarea>
        </div>



        
        <br/>
        <label>File</label><br/>
        <input class="form-control" type="file" @change="onFileChange($event)"/><br/>
        <button type="submit" class="btn btn-primary">Save</button>
        </form>
    </div>
</div>


</template>

<script>

export default {
    name: "AssetTile",
    data () {
        return {
            msg: '',
            formData: new FormData(),
            previewUrl: '',
            assetData: {
                name: '', 
                description: '', 
                file: null,
                coverImage: null,
                
            }
        }
    },
    methods: {
    getAssets: function () {
        this.formData.append('Name', this.assetData.name);
        this.formData.append('Description', this.assetData.description);
        this.formData.append('File', this.assetData.file);
        this.formData.append('CoverImage', this.assetData.coverImage);
        this.axios
        .post('https://localhost:5001/api/asset', this.formData)
        .then(result => {
            this.assetData.name = '';
            this.assetData.description = '';
            this.msg = 'Asset successfully uploaded!';
        })
    },

    onFileChange(e) {
        this.assetData.file = e.target.files[0];
    },

    onSubmit () {

        this.getAssets();
    },

    pickFile: function (event) {
        this.assetData.coverImage = event.target.files[0]
        const file = event.target.files[0]
        if (!file) {
            return false
        }
        if (!file.type.match('image.*')) {
            return false
        }
        const reader = new FileReader()
        const that = this
        reader.onload = function (e) {
            that.previewUrl = e.target.result
        }
        reader.readAsDataURL(file)
    },
  },
}
</script>

<style scoped>
* {
  box-sizing: border-box;
}

.container {
    padding: .5rem 2% 1rem 2%;
}

h1 {
    font-weight: normal;
}


output img {
    max-width: 100%;
    margin: 8px 0 16px 0;
    border: 1px solid #ced4da;
    border-radius: .25rem;
}

output p {
    background-color: #eeeeee;
    border: 1px solid #ced4da;
    margin: 8px 0 16px 0;
    border-radius: .25rem;
    padding: 8rem 9rem;
    text-align: center;
}
</style>