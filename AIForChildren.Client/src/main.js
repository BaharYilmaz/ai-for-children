import Vue from 'vue'
import App from './App.vue' 
import {router} from "./router"
//Module
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import Notifications from 'vue-notification';

//asset
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.config.productionTip = false

// Install BootstrapVue
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

//Notify
Vue.use(Notifications);


// Core stylesheets 
import "./assets/vendor/css/rtl/bootstrap.css" 
import "./assets/vendor/css/rtl/appwork.css"
import "./assets/vendor/css/rtl/theme-corporate.css"
import "./assets/vendor/css/rtl/colors.css"
import "./assets/vendor/css/rtl/uikit.css"
import "./assets/css/demo.css"


//Libs
import "./assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.css"

//Page
import "./assets/vendor/css/pages/authentication.css"

new Vue({
  render: h => h(App),
  router
}).$mount('#app')
