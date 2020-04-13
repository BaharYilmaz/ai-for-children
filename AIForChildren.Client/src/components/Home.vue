<template>
    <div id="home">
                <!-- Layout wrapper -->
        <div class="layout-wrapper layout-2">
            <div class="layout-inner">
            <!-- Layout container -->
            <div class="layout-container">
                <!-- Layout content -->
                <div class="layout-content">
                <!-- Content -->
                <div class="container-fluid flex-grow-1 container-p-y">   
                    <div class="row">
                    <!--1 content -->
                    <div class="col-sm-6 col-lg-4 col-xl-3">
                        <div class="card mb-4">
                        <div class="w-100">
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" :style="cssCar">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">Zorluk: Başlangıç</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="/arabaveyafincan" class="text-body">Araba veya Fincan</a></h5>
                            <p class="text-muted mb-3">Fotoğrafları gruplara ayırabilmek için bilgisayarı eğitin. Nesnelerin resimlerini tanımak için bilgisayara dokunun.</p>
                            
                        </div>
                        </div>
                    </div>
                    <!--/1 content -->
                     <!--1 content -->
                    <div class="col-sm-6 col-lg-3 col-xl-3">
                        <div class="card mb-4">
                        <div class="w-100">
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" :style="cssBukalemun">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">Zorluk: Başlangıç</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="/bukalemun" class="text-body">Bukalemun</a></h5>
                            <p class="text-muted mb-3">Scratch'ta rengini arka planına uyacak şekilde değiştiren bir bukalemun yapın.</p>
                        </div>
                        </div>
                    </div>
                    <!--/1 content -->
                     <!--1 content -->
                    <div class="col-sm-6 col-lg-3 col-xl-3">
                        <div class="card mb-4">
                        <div class="w-100">
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" :style="cssFind">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">Zorluk: İleri</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="/bulonu" class="text-body">Bul onu!</a></h5>
                            <p class="text-muted mb-3">Cep telefonunuz için bir saklambaç oyunu yapın.</p>
                        </div>
                        </div>
                    </div>
                    <!--/1 content -->
                    <!--1 content -->
                    <div class="col-sm-6 col-lg-3 col-xl-3">
                        <div class="card mb-4">
                        <div class="w-100">
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" :style="cssKivi">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">Zorluk: Başlangıç</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="/kiviveyagelincik" class="text-body">Kivi veya Gelincik</a></h5>
                            <p class="text-muted mb-3">Scratch'ta koruma alanlarındaki fotoğraflardaki hayvanları tanıyabilen bir proje yapın.</p>
                        </div>
                        </div>
                    </div>
                    <!--/1 content -->
                    <!--1 content -->
                    <div class="col-sm-6 col-lg-3 col-xl-3">
                        <div class="card mb-4">
                        <div class="w-100">
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" :style="cssHappy">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">Zorluk: Başlangıç</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="/benimutluet" class="text-body">Beni mutlu et!</a></h5>
                            <p class="text-muted mb-3">Scratch'ta hoş şeyler söylersen gülümseyen ve kötü şeyler söylersen ağlayan bir karakter yarat.
Bir bilgisayara iltifatları ve hakaretleri tanımasını öğretin.</p>
                        </div>
                        </div>
                    </div>
                    <!--/1 content -->
                    <!--1 content -->
                    <div class="col-sm-6 col-lg-3 col-xl-3" >
                        <div class="card mb-4">
                        <div class="w-100">
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" :style="cssLibrary">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">Zorluk: Orta seviye</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="/okulkütüphane" class="text-body">Okul kütüphanesi</a></h5>
                            <p class="text-muted mb-3">Scratch'da okuma kitabının kime uygun olabileceğini öneren bir okul kütüphanecisi oluşturun.</p>
                        </div>
                        </div>
                    </div>
                    <!--/1 content -->
                     <!--1 content -->
                    <div class="col-sm-6 col-lg-3 col-xl-3">
                        <div class="card mb-4">
                        <div class="w-100">
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" :style="cssClassroom">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">Zorluk: Başlangıç</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="/akıllısınıf" class="text-body">Akıllı Sınıf</a></h5>
                            <p class="text-muted mb-3">Scratch'da sanal cihazları kontrol etmenizi sağlayan bir akıllı asistan oluşturun. Bir bilgisayara komutlarınızın anlamını tanımasını sağlayın.</p>
                        </div>
                        </div>
                    </div>
                    <!--/1 content -->
                     <!--1 content -->
                    <div class="col-sm-6 col-lg-3 col-xl-3">
                        <div class="card mb-4">
                        <div class="w-100">
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" :style="cssHat">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">Zorluk: Orta seviye</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="/sapkasıralama" class="text-body">Sıralama Şapka</a></h5>
                            <p class="text-muted mb-3">Harry Potter'da olduğu gibi, söylediklerinize dayanarak sizi bir okul evine koyan bir Sıralama Şapkası oluşturun.Dil kullanımını tanımak için bir bilgisayara öğretin.</p>
                        </div>
                        </div>
                    </div>
                    <!--/1 content -->
                    </div>
                    <hr class="border-light mt-2 mb-4">
                   
                </div>
                <!-- / Content -->
                </div>
                <!-- Layout content -->
            </div>
            <!-- / Layout container -->
            </div>
            <!-- Overlay -->
        </div>
        <!-- / Layout wrapper -->
    </div>   
</template>

<script>
export default {
    name: "Home",
    data(){
      return{
        cssCar:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/araba.jpg')})`
        },
        cssBukalemun:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/bukalemun.png')})`
        },
        cssFind:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/buyutec.png')})`
        },
        cssKivi:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/kiviGelincik.jpg')})`
        },
        cssHappy:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/mutlu.jpg')})`
        },
        cssLibrary:{
            backgroundImage:`url(${require('@/assets/img/oyunlar/kütüphane.jpg')})`
        },
        cssClassroom:{
            backgroundImage:`url(${require('@/assets/img/oyunlar/smart.png')})`
        },
        cssHat:{
            backgroundImage:`url(${require('@/assets/img/oyunlar/sapka.jpg')})`
        }
      }
    }
}
</script>