import Vue from 'vue'

//Router
import VueRouter from "vue-router"
Vue.use(VueRouter);

//Components
import App from './App.vue' 
import Home from "./components/Home.vue"
import Register from "./components/Register.vue"
import Login from "./components/Login.vue"

Vue.config.productionTip = false

//Module
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
// Install BootstrapVue
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)


//Router
const router =new VueRouter({
  routes:[
    {path: "/", component: Home },
    {path: "/login", component: Login },
    {path: "/register", component: Register }
  ],
  mode:"history"
})
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
new Vue({
  render: h => h(App),
  router
}).$mount('#app')
