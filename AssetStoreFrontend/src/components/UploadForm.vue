<template>
    <div>
        <h1>Upload</h1>
        <label>title</label><br/>
        <input type="text" class="inputField"/>
        <br/>
        <label>description</label><br/>
        <textarea class="inputField"></textarea>
        <br/>
        <label>File</label><br/>
        <input type="file"/>
    </div>
</template>

<script>

export default {
    name: "AssetTile",
    props: {
        title: String,
        description: String
    },
    data () {
    return {
      assetData: {
          title: "", 
          description: "", 
          file: ""
        }
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