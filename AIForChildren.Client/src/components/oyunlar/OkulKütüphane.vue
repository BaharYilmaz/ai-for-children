<template>
    <div class="container-fluid flex-grow-1 container-p-y">
		<div v-if="!isLoading">
			<page-head icon="play-fill" title="Başla" />
			<div class="text-center">
				<!-- Layout wrapper -->
				<!-- Content --> 
					<div class="container-fluid flex-grow-1 container-p-y">
						<div class="row">
							<!--1 content -->
							<div class="col-sm-6 col-lg-4 col-xl-3 mx-auto" v-bind:key="oyun.id">
								<div class="card mb-4 border-primary ">
									<div class="w-100">
										<a href="javascript:void(0)" class="card-img-top d-block ui-rect-60 ui-bg-cover"
											v-bind:style="{ 'background-image': `url(` + oyun.image + `)` }">
											<div class="d-flex justify-content-between align-items-end ui-rect-content p-3">
												<div class="flex-shrink-1">
													<span class="badge badge-primary">{{ oyun.zorluk }}</span>
												</div>
											</div>
										</a>
									</div>
									<div class="card-body">
										<h5 class="mb-3"><a v-bind:href="oyun.link" class="text-body">{{ oyun.isim }}</a></h5>
										<p class="text-muted mb-3">{{oyun.icerik}}</p>
										<button class="btn btn-outline-info" @click="basla">Oyuna Başla</button>
									</div>
								</div>
							</div>
							<!--/1 content -->
						</div>
						<hr class="border-light mt-2 mb-4">
					</div>
					<!-- / Content -->
				<!-- / Layout wrapper -->
			</div>
		</div>
		
		<div v-if="isLoading">
			<page-head icon="play-fill" title="Okul Kütüphanesi" />
			<!-- Secenekler -->
			<div class="container-fluid flex-grow-1 container-p-y" v-if="secenekler">
				<div class="row">
					<!-- Train -->
					<div class="card border-info mb-3 bg-dark col-md-4 mx-auto" style="max-width: 18rem;">
						<div class="card-header bg-transparent border-info text-center text-warning">Train<p v-if="egitimSonu">
								(Yapıldı)</p>
						</div>
						<div class="card-body text-warning">
							<p class="card-text">Bilgisayarın öğrenmesi için karışık biçimde olan önceden tanımlanmış resimlerin bilgisayara öğretilmesi gerekir. Bu işleme makine öğrenmesinde "Train" işlemi denir. Tranin işlemi üç aşamadan oluşur. Bu aşamaları birazdan birlikte göreceğiz.</p>
						</div>
						<div class="card-footer bg-transparent border-info text-center">
							<button class="btn btn-outline-info text-warning" @click="train">Train</button>
						</div>
					</div>
					<!-- Test -->
					<div class="card border-info mb-3 bg-dark col-md-4 mx-auto" style="max-width: 18rem;">
						<div class="card-header bg-transparent border-info text-center text-warning">Test</div>
						<div class="card-body text-warning">
							<p class="card-text">Eğitilmiş model üzerinden bilgisayara daha önce hiç görmediği resimler verilir ve bu resimleri doğru tahmin etmesi beklenir. Bir çok denemeden sonra doğru bildiği ve yanlış bildiği resimler üzerinden yüzdesel olarak bir sonuç çıkarılır. Bu sonuç eğitilmiş modelin başarısıdır.</p>
						</div>
						<div class="card-footer bg-transparent border-info text-center">
							<button v-if="egitimSonu" class="btn btn-outline-info text-warning" @click="testt">Test</button>
							<p v-if="!egitimSonu" class="text-center text-danger">Lütfen ilk önce modeli eğitin!</p>
						</div>
					</div>
				</div>
			</div>
			<!-- Secenekler -->

			<!-- Train -->
			<div class="container-fluid" v-if="isTrain">
				<b-button block variant="success"><b>OKUMA DÜZEYLERİNE UYGUN KİTAPLAR İÇİN ÖZELLİKLERİ BELİRLEYELİM.</b></b-button>
				<div class="for" v-for="test in oyunlar"  v-bind:key="test.id">
					<div class="row justify-content-center">
						<!-- Mutlu -->
						<div class="card border-info mb-3 bg-success col-md-2 ml-2 mr-2 mt-2">
							<b-button block variant="warning"><b>{{test.baslik}}</b></b-button>
							<div class="wrapper mt-2">
								<b-button block variant="danger">{{test.icerik}}</b-button>
							</div>
							<div class="wrapper mt-2">
								<b-button block variant="danger">{{test.resimS}}</b-button>
							</div>
							<div class="wrapper mt-2">
								<b-button block variant="danger">{{test.satırS}}</b-button>
							</div>
							<div class="wrapper mt-2">
								<b-button block variant="danger">{{test.sayfaS}}</b-button>
							</div>
						</div>
						<div class="card border-info mb-3 bg-danger col-md-2 ml-2 mr-2 mt-2" v-for="kitap in kitaplar"  v-bind:key="kitap.id">
							<b-button block variant="warning"><b>{{kitap}}</b></b-button>
							<div class="wrapper mt-2">
								<h5>Resim Sayısı:</h5> <custom-slider min="0" max="30" step="5" v-model="slider2"/>
								<h5>Satır Sayısı:</h5> <custom-slider min="0" max="200" step="5" v-model="slider2"/>
								<h5>Sayfa Sayısı:</h5> <custom-slider min="0" max="150" step="5" v-model="slider2"/>
							</div>
						</div>
						<div class="card border-info mb-3 bg-success col-md-2 ml-2 mr-2 mt-2">
							<b-button block variant="warning"><b>ORNEK KİTAP</b></b-button>
							<b-button block variant="warning"><img :src=test.resim class="img-thumbnail"></b-button>
							<b-button block variant="warning">{{test.resimR}}</b-button>
							<b-button block variant="warning">{{test.resimSatır}}</b-button>
							<b-button block variant="warning">{{test.resimSayfa}}</b-button>
						</div>
					</div>
					<hr class="border-dark mt-2 mb-2">
				</div>
				<div class="text-center">
					<b-button block variant="success" class="text-dark" v-b-modal.modalEgit @click="libraryTrain">Eğit</b-button>
					
				</div>

			</div>
				
			<!-- ModalsTrain -->
			<div v-if="isLibraryTrain">
				<template>
					<div>
						<b-modal id="modalEgit" size="lg" title="Lütfen eğitim tamamlanmadan çıkmayın!" ok-only @ok="trainOk">
							<div class="text-center" v-if="!isEgitimBittiMi">
								<b-spinner variant="primary" label="Spinning"></b-spinner>
							</div>
							<div class="text-center mt-4 mb-4">
								<h4 v-if="veriOnIsleme">
									<b-icon icon="check" /> {{veriOnIsleme}}</h4>
								<h4 v-if="transformasyonu">
									<b-icon icon="check" /> {{transformasyonu}}</h4>
								<h4 v-if="egitimBaslangici">
									<b-icon icon="check" /> {{egitimBaslangici}}</h4>
								<h4 v-if="egitimSonu">
									<b-icon icon="check" /> {{egitimSonu}}</h4>
							</div>
							<template v-slot:modal-footer="{ ok }">
								<b class="text-danger" v-if="!egitimSonu">Lütfen eğitimin bitmesini bekleyin!</b>
								<b-button v-if="!egitimSonu" size="md" variant="danger" @click="ok">
									Durdur
								</b-button>
								<b-button v-if="egitimSonu" size="md" variant="info" @click="ok">
									Tamam
								</b-button>
							</template>
							<div v-if="isEgitimBittiMi">
								<fireworks></fireworks>
							</div>
						</b-modal>
					</div>
				</template>
			</div>
			<!-- /ModalsTrain -->
			<!-- /Train -->
			<!-- Test -->
			<div>
				<!-- TestSonuc -->
				<div v-if="tekSonuc">
					<h1 class="text-center mt-4 mb-4 bg-success">{{testSonuc}}</h1>
					<div v-if="tekSonuc" class="card border-info mb-3 bg-dark col-md-4 mx-auto" style="max-width: 18rem;">
						<div class="card-header bg-transparent border-info text-center text-warning">Seçiminiz</div>
						<div class="card-body text-warning">
							<img v-if="secim1Secildi" :src=resimler.son1 alt="kırmızı" class="img-thumbnail">
							<img v-if="secim2Secildi" :src=resimler.son2 alt="sarı" class="img-thumbnail">
							<img v-if="secim3Secildi" :src=resimler.son3 alt="sarı" class="img-thumbnail">
						</div>
					</div>
					<div class="text-center" v-if="tekSonuc">
						<h2 class="text-center bg-success" v-if="secim1Secildi">Seçilen kitap başlangıç düzeyi için uygundur.</h2>
						<h2 class="text-center bg-success" v-if="secim2Secildi">Seçilen kitap orta düzey için uygundur.</h2>
						<h2 class="text-center bg-success" v-if="secim3Secildi">Seçilen kitap ileri düzey için uygundur.</h2>
						<fireworks></fireworks>
						<div class="fixed-bottom mt-5 mb-5">
							<p>Tekrar oynamak için sayfayı yenileyin!</p>
							<router-link to="/">Anasayfa</router-link>
						</div>
					</div>
				</div>
			</div>
			<!-- TestSonuc -->
			<div class="container-fluid" v-if="isTest">
				<div class="mt-5 mb-5">
					<h3 v-if="!tumSonuclar" class="text-center bg-info">SEÇTİĞİN RESMİ TEST EDEBİLİRİZ VE BAKALIM KİTAP DÜZEYLERİNİ DÜZGÜN ÖĞRETEBİLDİK Mİ?</h3>
				</div>
				<div v-if="!isSecildiMi && !tumSonuclar" class="text-center">
					<div class="card border-info mb-3 bg-dark col-md-4 mx-auto" style="max-width: 18rem;">
						<div class="card-header bg-transparent border-info text-center text-warning">Seçimini Yap!</div>
						<div class="card-body text-warning">
							<p class="card-text">Lütfen bilgisayarın test etmesi için bir resim seçin!</p>
						</div>
						<div class="card-footer bg-transparent border-info text-center">
							<button class="btn btn-outline-info text-warning" v-b-modal.modalSec @click="secTest">Resim seç</button>
						</div>
					</div>
				</div>
				<div v-if="isSecildiMi" class="text-center">
					<div class="card border-info mb-3 bg-dark col-md-4 mx-auto" style="max-width: 18rem;">
						<div class="card-header bg-transparent border-info text-center text-warning">Seçiminiz</div>
						<div class="card-body text-warning">
							<img v-if="secim1Secildi" :src=resimler.test1 alt="kırmızı" class="img-thumbnail">
							<img v-if="secim2Secildi" :src=resimler.test2 alt="sarı" class="img-thumbnail">
							<img v-if="secim3Secildi" :src=resimler.test3 alt="sarı" class="img-thumbnail">
						</div>
						<div class="card-footer bg-transparent border-info text-center">
							<button v-if="!isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSec
								@click="secTest">Resim Seç</button>
							<button v-if="isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSenSecTestEt
								@click="libraryTest">Test Et</button>
						</div>
					</div>
				</div>
			</div>
		</div>

	<!-- ModalsSenSec -->
		<div v-if="onSec">
			<template>
				<div>
					<b-modal id="modalSec" size="lg" title="Lütfen bir resim seçin!" ok-only>
						<div class="row justify-content-center">
							<div class="col-md-3 ml-5 mr-5">
								<img :src=resimler.test1 alt="kırmızı" class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-success" @click="secim1">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<img :src=resimler.test2 alt="sarı" class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-success" @click="secim2">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<img :src=resimler.test3 alt="sarı" class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-success" @click="secim3">Seç</button>
								</div>
							</div>
						</div>
						<template v-slot:modal-footer="{ ok }">
							<b class="text-danger" v-if="!isSecildiMi">Lütfen bir resim seçmeden çıkmayın!</b>
							<b-button v-if="isSecildiMi" size="md" variant="info" @click="ok">
								Tamam
							</b-button>
						</template>
						<div v-if="isSecildiMi">
							<fireworks></fireworks>
						</div>
					</b-modal>
				</div>
			</template>
		</div>
		<!-- ModalsSenSec -->
		<!-- ModalsSenSecTestEt -->
		<div v-if="isLibraryTest">
			<template>
				<div>
					<b-modal id="modalSenSecTestEt" size="lg" title="Lütfen test tamamlanmadan çıkmayın!" ok-only
						@ok="modalSenSecTestEt">
						<div class="text-center" v-if="!isTestBittiMi">
							<b-spinner variant="primary" label="Spinning"></b-spinner>
						</div>
						<div class="text-center mt-4 mb-4">
							<h4 v-if="veriTestBaslangıc">
								<b-icon icon="check" /> {{veriTestBaslangıc}}</h4>
							<h4 v-if="veriTestSon">
								<b-icon icon="check" /> {{veriTestSon}}</h4>
						</div>
						<template v-slot:modal-footer="{ ok }">
							<b class="text-danger" v-if="!isTestBittiMi">Lütfen test işleminin bitmesini bekleyin!</b>
							<b-button v-if="isTestBittiMi" size="md" variant="info" @click="ok">
								Tamam
							</b-button>
						</template>
					</b-modal>
				</div>
			</template>
		</div>
		<!-- ModalsSenSecTestEt -->
	</div>
</template>

<script>
import CustomSlider from "vue-custom-range-slider";
import "vue-custom-range-slider/dist/vue-custom-range-slider.css";
export default {
	components: {
		CustomSlider
	},
	data(){
		return{
			name:"Okul Kütüphane",
			isLoading: false,
            secenekler: true,
            isTrain: false,
            isLibraryTrain: false,
            egitimSonu: "",
            veriOnIsleme: "",
            transformasyonu: "",
            egitimBaslangici: "",
			isEgitimBittiMi: false,
            isFireWorks: false, 
            isTest: false,
            isTestBittiMi: false,
            isLibraryTest: false,
            veriTestBaslangıc: "",
            veriTestSon: "",
            testSonuc: "",
            isSecildiMi: false,
            onSec: false,
            secim1Secildi: false,
			secim2Secildi: false,
			secim3Secildi: false,
            tumSonuclar: false,
			tekSonuc: false,
			resimler: {"son1":require('@/assets/img/oyunlar/library/son1.jpg'),"son2":require('@/assets/img/oyunlar/library/son2.jpg'),"son3":require('@/assets/img/oyunlar/library/son3.jpg'),"test1":require('@/assets/img/oyunlar/library/4.jpg'),"test2":require('@/assets/img/oyunlar/library/5.jpg'),"test3":require('@/assets/img/oyunlar/library/6.jpg'),},
			oyun:{"id":3,"image": require('@/assets/img/oyunlar/kutuphane2.jpg'),"zorluk": "Zorluk: Orta Seviye","link":"/okulkütüphane","isim": "Okul Kütüphanesi","icerik": "Scratch'da okuma kitabının kime uygun olabileceğini öneren bir okul kütüphanecisi oluşturun."},              
			kitaplar:["Kitap A","Kitap B","Kitap C"],
			oyunlar:[
				{"id":1,"baslik": "Başlangıç Düzey","icerik":"Başlangıç düzeyi öğrencilerin okumaya ilk adım attığı zamandır. Bundan dolayı okumayı teşvik edici görseller ve sayfalar, satırlar onları sıkmayacak kadar az olmalıdır.","resimS":"Resim Sayısı: 10-30 arasında olmalı.","satırS":"Satır Sayısı: 50 dan az olmalı.","sayfaS":"Sayfa Sayısı: 30 dan  az olmalı.","resim":require("@/assets/img/oyunlar/library/1.jpg"),"resimR":"Resim Sayısı: 20 ","resimSatır":"Satır Sayısı: 40","resimSayfa":"Sayfa Sayısı:25"},
				{"id":2,"baslik": "Orta Düzey","icerik":"Orta düzey artık öğrencilerin rahatlıkta kitap okuyabileceği, genel kültür edinebilecği , resimler daha az sayfa sayısı ve satır sayısının fazla olduğu kitaplardır.","resimS":"Resim Sayısı: 10-20 arasında olmalı.","satırS":"Satır Sayısı: 50-150 arasında olmalı.","sayfaS":"Sayfa Sayısı: 50-100 arasında olmalı.","resim":require("@/assets/img/oyunlar/library/2.jpg"),"resimR":"Resim Sayısı: 15 ","resimSatır":"Satır Sayısı: 100","resimSayfa":"Sayfa Sayısı: 75"},
				{"id":3,"baslik": "İleri Düzey","icerik":"İleri düzey resimsiz kitaplardan ve kalın kitaplardan oluşmaktadır. Daha fazla sayıda satır ve sayfalar bulunur.","resimS":"Resim Sayısı: 0-10 arasında olmalı.","satırS":"Satır Sayısı: 150 den fazla olmalı.","sayfaS":"Sayfa Sayısı: 100 den fazla olmalı.","resim":require("@/assets/img/oyunlar/library/3.jpg"),"resimR":"Resim Sayısı: 0 ", "resimSatır":"Satır Sayısı: 160","resimSayfa":"Sayfa Sayısı: 150"},
			],
		}
	},
	methods:{
		basla(){
			this.isLoading=true;
		},
		train(){
            this.secenekler = false;
            this.isTrain = true;
		},
		libraryTrain(){
            this.veriOnIsleme = "";
            this.transformasyonu = "";
            this.egitimBaslangici = "";
            this.egitimSonu = "";
            this.isEgitimBittiMi = false;
            this.isLibraryTrain = true;
            setTimeout(() => { 
                this.veriOnIsleme = "Verinin Ön İşlemesi.";
             }, 1000);
            setTimeout(() => { 
                this.transformasyonu = "Öznitelik Seçimi/Transformasyonu.";
             }, 2000);
            setTimeout(() => { 
                this.egitimBaslangici = "Eğitim başladı."
             }, 4500);
            setTimeout(() => { 
                this.egitimSonu = "Eğitim başarılı bir şekilde tamamlandı. Tebrikler!"
                this.isEgitimBittiMi = true
             }, 15600);
		},
		trainOk(){
            this.isLoading = true
            this.isTrain = false
            this.isLibraryTrain = false;
            this.secenekler = true;
        },
		testt(){
            this.secenekler = false;
            this.isTest = true;
            this.testSonuc = "";
            this.isTestBittiMi = false;
            this.secim1Secildi = false;
			this.secim2Secildi = false;
			this.secim3Secildi = false;
            this.isSecildiMi = false;
            this.onSec = false;
        },
        libraryTest(){
            this.veriTestBaslangıc = "";
            this.veriTestSon = "";
            this.isLibraryTest = true;
            setTimeout(() => { 
                this.veriTestBaslangıc = "Test işlemi başladı.";
             }, 2000);
            setTimeout(() => { 
                this.veriTestSon = "Test işlemi tamamlandı.";
                this.isTestBittiMi = true;
            }, 9000);
        },
        testOk(){
            this.isLoading = true
            this.isTrain = false
            this.isLibraryTrain = false;
            this.secenekler = false;
            this.testSonuc = "Test Sonuçları";
            this.tumSonuclar = true;
        },
        secTest(){
            this.onSec = true;
        },
        secim1(){
            this.isSecildiMi = true;
            this.secim1Secildi = true;
        },
        secim2(){
            this.isSecildiMi = true;
            this.secim2Secildi = true;
		},
		secim3(){
            this.isSecildiMi = true;
            this.secim3Secildi = true;
		},
        modalSenSecTestEt(){
            this.isLoading = true
            this.isTrain = false
            this.isLibraryTrain = false;
            this.secenekler = false;
            this.isTest = false;
            this.testSonuc = "Test Sonucu";
            this.tekSonuc = true;
		},
	}
}
</script>
