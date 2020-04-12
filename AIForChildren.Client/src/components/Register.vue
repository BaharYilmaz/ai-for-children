<template>
     <div class="authentication-wrapper authentication-3">
    <div class="authentication-inner">

      <!-- Side container -->
      <!-- Do not display the container on extra small, small and medium screens -->
      <div class="d-none d-lg-flex col-lg-8 align-items-center ui-bg-cover ui-bg-overlay-container p-5" :style="cssProps">
        <div class="ui-bg-overlay bg-dark opacity-50"></div>

        <!-- Text -->
        <div class="w-100 text-white px-5">
          <h1 class="display-2 font-weight-bolder mb-4">ARTIFICIAL INTELLIGENCE<br>FOR KIDS</h1>
          <div class="text-large font-weight-light">
            Çocuklar yapay zeka ile büyüyor.
          </div>
        </div>
        <!-- /.Text -->
      </div>
      <!-- / Side container -->
      
      <!-- Form container -->
      <div class="d-flex col-lg-4 align-items-center bg-white p-5">
        <!-- Inner container -->
        <!-- Have to add `.d-flex` to control width via `.col-*` classes -->
        <div class="d-flex col-sm-7 col-md-5 col-lg-12 px-0 px-xl-4 mx-auto">
          <div class="w-100">

            <!-- Logo 
            <div class="d-flex justify-content-center align-items-center">
              <div class="ui-w-60">
                <div class="w-100 position-relative" style="padding-bottom: 54%">
                </div>
              </div>
            </div>
             / Logo -->

            <h4 class="text-center text-lighter font-weight-normal mt-5 mb-0">Hesap Oluştur</h4>

            <!-- Form -->
            <form class="my-5">
              <div class="form-group">
                <label class="form-label">İsim</label>
                <input type="text" class="form-control" v-model="model.kullaniciAdi">
              </div>
              <div class="form-group">
                <label class="form-label">Email</label>
                <input type="text" class="form-control" v-model="model.email">
              </div>
              <div class="form-group">
                <label class="form-label">Şifre</label>
                <input type="password" class="form-control" v-model="model.sifre">
              </div>
              <button type="button"  @click="save" class="btn btn-success btn-block mt-4">Kayıt Ol</button>
              <div class="text-light small mt-4">
               <!--  By clicking "Sign Up", you agree to our
                <a href="javascript:void(0)">terms of service and privacy policy</a>. We’ll occasionally send you account related emails.
                -->
              </div> 
            </form>
            <!-- / Form -->

            <div class="text-center text-muted">
              Zaten hesabınız var mı? <a href="/login">Giriş Yap</a>
            </div>

          </div>
        </div>
      </div>
      <!-- / Form container -->

    </div>
  </div>

</template>

<script>
import service from "../services/authentication";

export default {
    name:"Register",
    data(){
      return{
        cssProps:{
          backgroundImage:`url(${require('@/assets/img/bg/c3.png')})`
        },
        model: {
          kullaniciAdi: "",
          email: "",
          sifre: ""
        },
        result:{}
      }
    },
     methods: {
      async save() {
        var result = await service.save(this.model);
        this.result = result;
        console.log(result);
      }
    }
}
</script>
