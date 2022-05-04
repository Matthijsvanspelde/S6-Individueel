<template>

<h5>Browse assets</h5>
  <div class="row row-cols-2" >
    <AssetTile  class="col-4"/>
    <AssetTile  class="col-4"/>
    <AssetTile  class="col-4"/>
    <AssetTile  class="col-4"/>
    <AssetTile  class="col-4"/>
    <AssetTile  class="col-4"/>
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
.container {
  
}
</style>
