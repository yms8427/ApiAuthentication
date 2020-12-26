<template>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="#">Northwind</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="#">Ürünler</a>
      </li>
    </ul>
  </div>
</nav>
<div class="container">
  <Products />
</div>
</template>

<script>
import Products from './components/Products.vue'

export default {
  name: 'App',
  components: {
    Products
  }
}
</script>
