<template>
    <div class="item">
      <h3>{{this.title}}</h3>
      <p>{{this.description}}</p>
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
</style>
