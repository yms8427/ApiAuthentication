import { createRouter, createWebHistory } from "vue-router";
import Login from "../views/Login.vue";
import Register from "../views/Register.vue";
import Products from "../views/Products.vue";
import Employees from "../views/Employees.vue";
import ProductDetail from "../views/ProductDetail.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Products
  },
  {
    path: "/login",
    name: "Login",
    component: Login
  },
  {
    path: "/register",
    name: "Register",
    component: Register
  },
  {
    path: "/employees",
    name: "Employees",
    component: Employees
  },
  {
    path: "/product-detail/:id",
    name: "Product Detail",
    component: ProductDetail
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;
