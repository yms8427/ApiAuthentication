<template>
  <div class="card">
    <div class="card-header">
      Giriş yap
    </div>
    <div class="card-body">
      <div class="alert alert-warning" v-if="isLoginFailed">
        Giriş başarısız
      </div>
      <div class="form-group">
        <label for="txtusername">Kullanıcı adı</label>
        <input
          id="txtusername"
          type="text"
          v-model="username"
          class="form-control"
        />
      </div>
      <div class="form-group">
        <label for="txtpassword">Şifre</label>
        <input
          id="txtpassword"
          type="password"
          v-model="password"
          class="form-control"
        />
      </div>
    </div>
    <div class="card-footer text-muted">
      <button class="btn btn-primary float-right" @click="login">
        Giriş Yap
      </button>
      <router-link class="btn btn-primary float-right mr-2" to="/register"
        >Kayıt Ol</router-link
      >
    </div>
  </div>
</template>
<script>
import axios from "axios";
export default {
  name: "Login",
  data() {
    return {
      username: "",
      password: "",
      isLoginFailed: false,
    };
  },
  methods: {
    login() {
      const headers = {
        "Content-Type": "application/json",
      };

      axios
        .post(
          "https://localhost:5001/api/account/login",
          {
            username: this.username,
            password: this.password,
          },
          {
            headers: headers,
          }
        )
        .then((response) => {
          localStorage.setItem("token", response.data);
          this.$router.push("/");
        })
        .catch((error) => {
          if (error.response) {
            if (error.response.data === "incorrect credentials") {
              this.isLoginFailed = true;
              this.password = "";
            }
          }
        });
    },
  },
};
</script>
<style scoped>
.card {
  margin: 0 auto;
}
</style>
