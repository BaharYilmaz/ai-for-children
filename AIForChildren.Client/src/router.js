import Vue from 'vue'
import VueRouter from "vue-router"

Vue.use(VueRouter);

import Home from "./components/Home.vue"
import Register from "./components/Register.vue"
import Login from "./components/Login.vue"

import ArabaKupa from "./components/oyunlar/ArabaKupa.vue"
import Bukalemun from "./components/oyunlar/Bukalemun.vue"
import BulOnu from "./components/oyunlar/BulOnu.vue"
import KiviVeyaGelincik from "./components/oyunlar/KiviGelincik.vue"
import BeniMutluEt from "./components/oyunlar/BeniMutluEt.vue"
import OkulKutuphane from "./components/oyunlar/OkulKütüphane.vue"
import SapkaSıralama from "./components/oyunlar/SapkaSıralama.vue"
import AkıllıSınıf from "./components/oyunlar/AkıllıSınıf.vue"


//Router
export const router =new VueRouter({
    routes:[
      {path: "/", component: Home },
      {path: "/login", component: Login },
      {path: "/register", component: Register },


      {path: "/arabaveyakupa", component: ArabaKupa },
      {path: "/bukalemun", component: Bukalemun },
      {path: "/bulonu", component: BulOnu },
      {path: "/kiviveyagelincik", component: KiviVeyaGelincik},
      {path: "/benimutluet", component: BeniMutluEt },
      {path: "/okulkütüphane", component: OkulKutuphane},
      {path: "/sapkasıralama", component: SapkaSıralama },
      {path: "/akıllısınıf", component: AkıllıSınıf},      

    ],
    mode:"history"
  })
