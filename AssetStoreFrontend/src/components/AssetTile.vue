<template>
<div>
<div class="card">
 
  <h5 class="card-header">
    {{this.title}}
  </h5>
  <img class="card-img-top" src="/src/assets/Banner.png" alt="Card image cap">
  <div class="card-body">
    <p class="card-text">{{this.description}}</p>
    <a v-on:click="onSubmit()" href="#" class="btn btn-primary">Download</a>
  </div>
  <div class="card-footer">
      <small class="text-muted">Last updated 6 mins ago by <b>{{this.user}}</b></small>
  </div>
</div>
</div>

</template>

<script>

export default {
  name: "AssetTile",
  props: {
    title: String,
    description: String,
    user: Array
  },
  data () {
        return {

        }
    },
    methods: {
    onSubmit () {
        this.axios
        .get('https://localhost:5001/api/asset/download/2', { responseType: 'blob' })
        .then(result => {
          var fileURL = window.URL.createObjectURL(new Blob([result.data]));
          var fileLink = document.createElement('a');
        
          fileLink.href = fileURL;
          fileLink.setAttribute('download', 'animaties.zip');
          document.body.appendChild(fileLink);
        
          fileLink.click();

        })
    },
  }
}
</script>

<style scoped>


.item {
  width: 228px;
  height: 228px;
  background-color: rgb(255, 255, 255);
  padding: 6px;
  border-radius: 4px;
  box-shadow: rgba(99, 99, 99, 0.1) 0px 2px 8px 0px;
  transition: transform .1s; /* Animation */
}

.item:hover {
  transform: scale(1.05);
  cursor: pointer;
}

.card {
  margin-bottom: 14px;
}

.card:hover{
    transform:scale(1.025);
    cursor: pointer;
}
</style>
