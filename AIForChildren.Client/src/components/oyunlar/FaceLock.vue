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
			<page-head icon="play-fill" title="Yüz Kilidi" />
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
				<b-button block variant="success"><b>Makineye Baba Simpson'u öğretelim.</b></b-button>
				<div class="row justify-content-center">
					<!-- Mutlu -->
					<div class="card border-info mb-3 bg-dark col-md-2 ml-2 mr-2 mt-2" v-for="(resim, index) in resimler" :key="index">
						<div class="form-group btn-sm btn-success mt-2">
							<select class="form-control btn-success " id="sel1">
								<option>Seçiniz</option>
								<option>Baba Simpson</option>
								<option>Başkası</option>
							</select>
						</div>
						<div class="card-body text-warning">
							<img :src=resim class="img-thumbnail">
						</div>
					</div>
				</div>

				<div class="text-center">
					<b-button block variant="success" class="text-dark" v-b-modal.modalEgit @click="lockTrain">Eğit</b-button>
				</div>

			</div>
				
			<!-- ModalsTrain -->
			<div v-if="isLockTrain">
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
							<img v-if="secim1Secildi" :src=test.basarili alt="kırmızı" class="img-thumbnail">
							<img v-if="secim2Secildi" :src=test.hata alt="sarı" class="img-thumbnail">
						</div>
					</div>
					<div class="text-center" v-if="tekSonuc">
						<h2 class="text-center bg-success" v-if="secim1Secildi">Tebrikler Kilit Açıldı.</h2>
						<h2 class="text-center bg-success" v-if="secim2Secildi">Tebrikler Makine Öğrenmesi Başarılı. Artık Başkaları Telefona Erişemiyor.</h2>
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
					<h3 v-if="!tumSonuclar" class="text-center bg-info">SEÇTİĞİN RESMİ TEST EDEBİLİRİZ VE BAKALIM TELEFONA GİREBİLECEK MİYİZ?</h3>
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
							<img v-if="secim1Secildi" :src=test.test1 alt="kırmızı" class="img-thumbnail">
							<img v-if="secim2Secildi" :src=test.test2 alt="sarı" class="img-thumbnail">
						</div>
						<div class="card-footer bg-transparent border-info text-center">
							<button v-if="!isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSec
								@click="secTest">Resim Seç</button>
							<button v-if="isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSenSecTestEt
								@click="lockTest">Test Et</button>
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
								<img :src=test.test1 alt="kırmızı" class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-success" @click="secim1">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<img :src=test.test2 alt="sarı" class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-success" @click="secim2">Seç</button>
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
		<div v-if="isLockTest">
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
    import service from "../../services/gamePlay";

    export default {
    
	data(){
		return{
			name:"FaceLock",
			isLoading: false,
            secenekler: true,
            isTrain: false,
            isLockTrain: false,
            egitimSonu: "",
            veriOnIsleme: "",
            transformasyonu: "",
            egitimBaslangici: "",
			isEgitimBittiMi: false,
            isFireWorks: false, 
            isTest: false,
            isTestBittiMi: false,
            isLockTest: false,
            veriTestBaslangıc: "",
            veriTestSon: "",
            testSonuc: "",
            isSecildiMi: false,
            onSec: false,
            secim1Secildi: false,
			secim2Secildi: false,
            tumSonuclar: false,
            tekSonuc: false,
			resimler: [require('@/assets/img/oyunlar/facelock/1.jpg'),require('@/assets/img/oyunlar/facelock/2.jpg'),require('@/assets/img/oyunlar/facelock/3.jpg'),require('@/assets/img/oyunlar/facelock/4.jpg'),require('@/assets/img/oyunlar/facelock/5.png'),require('@/assets/img/oyunlar/facelock/6.png'),require('@/assets/img/oyunlar/facelock/7.jpg'),require('@/assets/img/oyunlar/facelock/8.jpg'),require('@/assets/img/oyunlar/facelock/9.jpg'),require('@/assets/img/oyunlar/facelock/10.jpg'),require('@/assets/img/oyunlar/facelock/11.png'),require('@/assets/img/oyunlar/facelock/12.png'),require('@/assets/img/oyunlar/facelock/13.jpg'),require('@/assets/img/oyunlar/facelock/14.jpg'),require('@/assets/img/oyunlar/facelock/15.png')],     
			oyun: {"id":10,"image": require('@/assets/img/oyunlar/facelock.jpg'),"zorluk": "Zorluk: Başlangıç","link":"/yüzkilidi","isim": "Yüz Kilidi","icerik": "Yüzünüzü tanıdığında kilidi açılan bir telefon yapın. Bunun için önce bilgisayara yüzleri tanımasını öğretin."},
			test:{"test1":require("@/assets/img/oyunlar/facelock/2.jpg"),"test2":require("@/assets/img/oyunlar/facelock/14.jpg"),"hata":require("@/assets/img/oyunlar/facelock/hata.png"),"basarili":require("@/assets/img/oyunlar/facelock/basarili.jpg"),},
		}
	},
	methods:{
      async basla(){
          this.isLoading=true;
          var result = await service.play();
          console.log(result);
      },
		train(){
            this.secenekler = false;
            this.isTrain = true;
		},
		lockTrain(){
            this.veriOnIsleme = "";
            this.transformasyonu = "";
            this.egitimBaslangici = "";
            this.egitimSonu = "";
            this.isEgitimBittiMi = false;
            this.isLockTrain = true;
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
            this.isLockTrain = false;
            this.secenekler = true;
        },
		testt(){
            this.secenekler = false;
            this.isTest = true;
            this.testSonuc = "";
            this.isTestBittiMi = false;
            this.secim1Secildi = false;
            this.secim2Secildi = false;
            this.isSecildiMi = false;
            this.onSec = false;
        },
        lockTest(){
            this.veriTestBaslangıc = "";
            this.veriTestSon = "";
            this.isLockTest = true;
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
            this.isLockTrain = false;
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
        modalSenSecTestEt(){
            this.isLoading = true
            this.isTrain = false
            this.isLockTrain = false;
            this.secenekler = false;
            this.isTest = false;
            this.testSonuc = "Test Sonucu";
            this.tekSonuc = true;
        }
	}
}
</script>