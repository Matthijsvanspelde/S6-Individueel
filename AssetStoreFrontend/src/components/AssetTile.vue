<template>
<div>
<div class="card">
  <h5 class="card-header">
    Asset Name
  </h5>
  <div class="card-body">
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
</div>
</div>

</template>

<script>

export default {
  name: "AssetTile",
  props: {
    title: String,
    description: String
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
