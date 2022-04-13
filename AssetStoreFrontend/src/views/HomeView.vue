<template>
<div class="container">
  <h1>Browse assets</h1>
  <div class="box">
    <div v-for="asset in assets" v-bind:key="asset.id" >
      <AssetTile :title="asset.title" :description="asset.description"/>
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
      .get('http://assetstore.com/api/asset')
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

</style>
