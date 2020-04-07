import Vue from 'vue'
import VueRouter from "vue-router"

Vue.use(VueRouter);

import Home from "./components/Home.vue"
import Register from "./components/Register.vue"
import Login from "./components/Login.vue"

//Router
export const router =new VueRouter({
    routes:[
      {path: "/", component: Home },
      {path: "/login", component: Login },
      {path: "/register", component: Register }
    ],
    mode:"history"
  })
