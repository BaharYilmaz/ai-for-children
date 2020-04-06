import Vue from 'vue'

//Router
import VueRouter from "vue-router"
Vue.use(VueRouter);
//asset
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

// Icon fonts 
/*import "./assets/vendor/fonts/fontawesome.css"
import "./assets/vendor/fonts/ionicons.css"
import "./assets/vendor/fonts/open-iconic.css"
import "./assets/vendor/fonts/pe-icon-7-stroke.css"*/

// Core stylesheets 
import "./assets/vendor/css/rtl/appwork.css"
import "./assets/vendor/css/rtl/theme-corporate.css"
import "./assets/vendor/css/rtl/colors.css"
import "./assets/vendor/css/rtl/uikit.css"
import "./assets/css/demo.css"

/*
//Load polyfills
import "./assets/vendor/js/polyfills.js"
  /*document*//*
import "./assets/vendor/js/material-ripple.js"
import "./assets/vendor/js/layout-helpers.js"
*/

//Core scripts
//import "./assets/vendor/js/pace.js"
//import "https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"

//Libs
import "./assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.css"

//Page
import "./assets/vendor/css/pages/authentication.css"

//CONTENT
//<!-- Core scripts -->
//import "./assets/vendor/libs/popper/popper.js"
//import "./assets/vendor/js/bootstrap.js"
//import "./assets/vendor/js/sidenav.js"

//<!-- Libs -->
//import "./assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.js"

//<!-- Demo -->
//import "./assets/js/demo.js"

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

new Vue({
  render: h => h(App),
  router
}).$mount('#app')
