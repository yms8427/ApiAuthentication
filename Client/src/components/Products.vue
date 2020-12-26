<template>
  <h1 class="display-2">Ürünler</h1>
  <button class="btn btn-primary mb-5" @click="load">Getir</button>
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
</template>

<script>
import axios from "axios";
export default {
  name: "HelloWorld",
  data() {
    return {
      data: [],
      pageNumber: 1,
      count: 10,
      token: "",
    };
  },
  mounted() {
    this.getToken();
  },
  methods: {
    getToken() {
      if (!this.token) {
        const headers = {
          "Content-Type": "application/json",
        };

        axios
          .post(
            "https://localhost:5001/api/account/login",
            {
              username: "can",
              password: "123",
            },
            {
              headers: headers,
            }
          )
          .then((response) => {
            this.token = response.data;
          })
          .catch((error) => {
            if (error.response) {
              console.log(error);
            }
          });
      }
    },
    load() {
      const headers = {
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      };
      axios
        .get("https://localhost:5001/api/product/list?page=1&count=10", {
          headers: headers,
        })
        .then((response) => {
          this.data = response.data;
        })
        .catch((error) => {
          if (error.response) {
            console.log(error);
          }
        });
    },
  },
};
</script>
