<template>
  <h1 class="display-2">Ürünler</h1>
  <table class="table table-striped table-hover">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Ürün Adı</th>
        <th scope="col">Fiyatı</th>
        <th scope="col">Stok</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="p in data" :key="p.id">
        <th scope="row">{{ p.id }}</th>
        <td>{{ p.name }}</td>
        <td>{{ p.price }}</td>
        <td>{{ p.stock }}</td>
      </tr>
    </tbody>
  </table>
  <div>
    <button
      class="btn btn-danger mr-2"
      @click="previous"
      :disabled="pageNumber === 1"
    >
      Önceki
    </button>
    <button class="btn btn-danger" @click="next" :disabled="data.length < 10">
      Sonraki
    </button>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Products",
  data() {
    return {
      data: [],
      pageNumber: 1,
      count: 10,
      token: "",
    };
  },
  mounted() {
    const token = localStorage.getItem("token");
    if (!token) {
      this.$router.push("/login");
    } else {
      this.token = token;
      this.load();
    }
  },
  methods: {
    load() {
      const headers = {
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      };
      axios
        .get(
          `https://localhost:5001/api/product/list?page=${this.pageNumber}&count=10`,
          {
            headers: headers,
          }
        )
        .then((response) => {
          this.data = response.data;
        })
        .catch((error) => {
          if (error.response) {
            localStorage.clear();
            this.$router.push("/login");
          }
        });
    },
    next() {
      this.pageNumber++;
      this.load();
    },
    previous() {
      this.pageNumber--;
      this.load();
    },
  },
};
</script>
