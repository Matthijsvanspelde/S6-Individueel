<template>
    <div class="card">
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

.card {
  padding: 16px;
  text-align: center;
  background-color: #ffffff;
  margin: 50px;
  border-radius: 6px;
  box-shadow: rgba(99, 99, 99, 0.1) 0px 2px 8px 0px;
  left: 0;
  transition: 0.2s;
}

.card:hover {
  left: 10px;
  cursor: pointer;
}

</style>
