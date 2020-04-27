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
                    <div class="col-sm-6 col-lg-4 col-xl-3"  v-for="oyun in oyunlar"  v-bind:key="oyun.id">
                        <div class="card mb-4">
                        <div class="w-100" >
                            <a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover" v-bind:style="{ 'background-image': `url(` + oyun.image + `)` }">
                            <div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
                                <div class="flex-shrink-1">
                                <span class="badge badge-primary">{{ oyun.zorluk }}</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a v-bind:href="oyun.link"   class="text-body">{{ oyun.isim }}</a></h5>
                            <p class="text-muted mb-3">{{oyun.icerik}}</p>
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
        oyunlar: [
              {"id":1,"image": require('@/assets/img/oyunlar/araba.jpg'),"zorluk": "Zorluk: Başlangıç","link":"/arabaveyakupa","isim": "Araba veya Kupa","icerik": "Fotoğrafları gruplara ayırabilmek için bilgisayarı eğitin. Daha sonra nesneleri nasıl tanıdığımızı görmek için test edin."},
              {"id":2,"image": require('@/assets/img/oyunlar/bukalemun.png'),"zorluk": "Zorluk: Başlangıç","link":"/bukalemun","isim": "Bukalemun","icerik": "Renkleri ayırt edebilmek için bilgisayarı eğitin. Daha sonra rengini arka planına uyacak şekilde değiştiren bir bukalemun yapın."},
              {"id":3,"image": require('@/assets/img/oyunlar/kutuphane2.jpg'),"zorluk": "Zorluk: Orta Seviye","link":"/okulkütüphane","isim": "Okul Kütüphanesi","icerik": "Scratch'da okuma kitabının kime uygun olabileceğini öneren bir okul kütüphanecisi oluşturun."},              
              {"id":4,"image": require('@/assets/img/oyunlar/kiviGelincik.jpg'),"zorluk": "Zorluk: Başlangıç","link":"/kiviveyagelincik","isim": "Kivi veya Gelincik","icerik": "Scratch'ta koruma alanlarındaki fotoğraflardaki hayvanları tanıyabilen bir proje yapın."},
              {"id":5,"image": require('@/assets/img/oyunlar/buyutec.png'),"zorluk": "Zorluk: İleri","link":"/bulonu","isim": "Bul onu!","icerik": "Cep telefonunuz için bir saklambaç oyunu yapın"},
              {"id":6,"image": require('@/assets/img/oyunlar/mutlu.jpg'),"zorluk": "Zorluk: Başlangıç","link":"/benimutluet","isim": "Beni mutlu et!","icerik": "Kimin güldüğünü kimin üzüldüğünü bilgisayara öğretin. Daha sonra sizin seçtiğiniz resimlerden kimin mutlu kimin mutsuz olduğunu tahmin edelim."},
              {"id":7,"image": require('@/assets/img/oyunlar/sapka.jpg'),"zorluk": "Zorluk: Orta Seviye","link":"/sapkasıralama","isim": "Seçmen Şapka","icerik": "Harry Potter'da olduğu gibi, söylediklerinize dayanarak sizi bir okul evine koyan bir Sıralama Şapkası oluşturun.Dil kullanımını tanımak için bir bilgisayara öğretin."},
              {"id":8,"image": require('@/assets/img/oyunlar/smart.png'),"zorluk": "Zorluk: Başlangıç","link":"/akıllısınıf","isim": "Akıllı Sınıf","icerik": "Scratch'da sanal cihazları kontrol etmenizi sağlayan bir akıllı asistan oluşturun. Bir bilgisayara komutlarınızın anlamını tanımasını sağlayın."},
              {"id":9,"image": require('@/assets/img/oyunlar/titanic.jpg'),"zorluk": "Zorluk: Başlangıç","link":"/titanic","isim": "Titanic","icerik": "Titanik'in batmasıyla kimin hayatta kalacağını tahmin edebilecek bir Python programı oluşturun.Bir bilgisayara sonuçları tahmin etmesini öğretin."},
              {"id":10,"image": require('@/assets/img/oyunlar/facelock.jpg'),"zorluk": "Zorluk: Başlangıç","link":"/yüzkilidi","isim": "Yüz Kilidi","icerik": "Scratch'ta yüzünüzü tanıdığında kilidi açılan bir telefon yapın. Bilgisayara yüzleri tanımasını öğretin"},
          ],
      }
       
    }
}
</script>