<template>
<div class="hcontainer">
<h5>Browse assets</h5>
<div class="alert alert-primary" role="alert">
  The Asset Store is a simple way to find and share game assets online for free. <a href="">Add your asset</a> or <a href="">Read the FAQ</a>
</div>

  <div class="row row-cols-2" >
    <div v-for="asset in this.assets" v-bind:key="asset.id">
      <AssetTile :title="asset.name" :description="asset.description" :user="asset.user.username"/>
    </div>
    

  </div>
   </div>
</template>

<script>
import AssetTile from "@/components/AssetTile.vue";
export default {
  name: "HomeView",
  components: {
    AssetTile
  },
  data () {
    return {
      assets: null
    }
  },
  methods: {
    getAssets: function () {
      this.axios
      .get('https://localhost:5001/api/asset')
      .then(response => (
        this.assets = response.data
        )        
      )
    }
  },

  mounted () {
    this.getAssets();
  }
}
</script>

<style>
.hcontainer {
  left: 20%;
  margin-top: 80px;
  max-width: 1200px;
}
</style>
