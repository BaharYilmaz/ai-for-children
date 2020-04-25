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
			<page-head icon="play-fill" title="Titanic"/>
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
							<button v-if="egitimSonu" class="btn btn-outline-info text-warning" @click="test">Test</button>
							<p v-if="!egitimSonu" class="text-center text-danger">Lütfen ilk önce modeli eğitin!</p>
						</div>
					</div>
				</div>
			</div>
			<!-- Secenekler -->
			<!-- Train -->
			<div class="container-fluid" v-if="isTrain">
				<b-button class="mt-2 mb-2" block variant="warning"><b>İpucu!! Makinenin komutları anlması için ilgili cümleleri öğretelim.</b></b-button>
				<b-button class="mt-2 mb-2" block variant="danger"><b>İpucu!! Unutmayın her komut için 6 cümle olacak. Eksik olmasın. :)</b></b-button>
				<main class="flexbox" v-bind:style="{ 'width': '100%'}">
                    <Board id="board-1">
						<div class="siralama"  v-for="kart in kartlar"  v-bind:key="kart.id">
							<Card v-bind:id="kart.cardId" draggable="true" v-bind:style="{ 'background-color': 'lightgreen'}">
								<p>{{kart.icerik}}</p>
							</Card>
						</div>
                    </Board>
				</main>

				<main class="flexbox">
					<div class="col-3">
						<b-button class="mt-2 mb-2" block variant="warning"><b>Vantilatörü Aç</b></b-button>
					</div>
					<div class="col-9">
						<Board id="board-2">
							<Card id="card-1" draggable="true" v-bind:style="{ 'background-color': 'red'}">
                            	<p>Öğlen vakti hava çok sıcak olur.</p>
                        	</Card>
						</Board>
					</div>
				</main>
				<main class="flexbox">
					<div class="col-3">
						<b-button class="mt-2 mb-2" block variant="warning"><b>Vantilatörü Kapat</b></b-button>
					</div>
					<div class="col-9">
						<Board id="board-3">
							<Card id="card-2" draggable="true" v-bind:style="{ 'background-color': 'red'}">
								<p>Hava rüzgarlı.</p>
							</Card>
						</Board>
					</div>
				</main>
				<main class="flexbox">
					<div class="col-3">
						<b-button class="mt-2 mb-2" block variant="warning"><b>Işık Aç</b></b-button>
					</div>
					<div class="col-9">
						<Board id="board-4">
							<Card id="card-3" draggable="true" v-bind:style="{ 'background-color': 'red'}">
                           		<p>Akşam oldu.</p>
                        	</Card>
						</Board>
					</div>	
                </main>
                <main class="flexbox">
					<div class="col-3">
						<b-button class="mt-2 mb-2" block variant="warning"><b>Işık kapat.</b></b-button>
					</div>
					<div class="col-9">
						<Board id="board-5">
							<Card id="card-4" draggable="true" v-bind:style="{ 'background-color': 'red'}">
                           		<p>Güneş doğuyor ışıkları kapatabiliriz.</p>
                        	</Card>
						</Board>
					</div>	
                </main>
				<div class="text-center">
					<b-button block variant="success" class="text-dark" v-b-modal.modalEgit @click="smartTrain">Eğit</b-button>
				</div>
			</div>
			<!-- ModalsTrain -->
			<div v-if="isSmartTrain">
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
			<!-- ModalsTrain -->
			<!-- Train -->
			<!-- Test -->
			<div>
				<!-- TestSonuc -->
				<div v-if="tekSonuc">
					<h1 class="text-center mt-4 mb-4 bg-success">{{testSonuc}}</h1>
					<div v-if="tekSonuc" class="card border-info mb-3 bg-dark col-md-4 mx-auto" style="max-width: 18rem;">
						<div class="card-header bg-transparent border-info text-center text-warning">Seçiminiz</div>
						<div class="card-body text-warning">
							<img v-if="secim1Secildi" :src=resimler.openFan alt="openFan" class="img-thumbnail">
							<img v-if="secim2Secildi" :src=resimler.closeFan alt="closeFan" class="img-thumbnail">
							<img v-if="secim3Secildi" :src=resimler.openLamb alt="openLamb" class="img-thumbnail">
							<img v-if="secim4Secildi" :src=resimler.closeLamb alt="closeLamb" class="img-thumbnail">
							<img v-if="secim5Secildi" :src=resimler.hata alt="closeLamb" class="img-thumbnail">
						</div>
					</div>
					<div class="text-center" v-if="tekSonuc">
						<h2 class="text-center bg-success" v-if="secim1Secildi">Komut: Vantilatörü Aç</h2>
						<h2 class="text-center bg-success" v-if="secim2Secildi">Komut: Vantilatörü Kapat</h2>
						<h2 class="text-center bg-success" v-if="secim3Secildi">Komut: Işığı Aç</h2>
						<h2 class="text-center bg-success" v-if="secim4Secildi">Komut: Işığı Kapat</h2>
						<h2 class="text-center bg-success" v-if="secim5Secildi">Ne demek istediğini anlamadım.!!</h2>
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
					<h3 v-if="!tumSonuclar" class="text-center bg-info">İSTERSEN SENİN SEÇİMİNİ TEST EDEBİLİRİZ</h3>
				</div>
				<div v-if="!isSecildiMi" class="text-center">
					<div class="card border-info mb-3 bg-dark col-md-4 mx-auto" style="max-width: 18rem;">
						<div class="card-header bg-transparent border-info text-center text-warning">Seçimini Yap!</div>
						<div class="card-body text-warning">
							<p class="card-text">Lütfen bilgisayarın test etmesi için bir metni seçin!</p>
						</div>
						<div class="card-footer bg-transparent border-info text-center">
							<button class="btn btn-outline-info text-warning" v-b-modal.modalSec @click="secTest">Seç</button>
						</div>
					</div>
				</div>
				<div v-if="isSecildiMi" class="text-center">
					<div class="card border-info mb-3 bg-dark col-md-4 mx-auto" style="max-width: 18rem;">
						<div class="card-header bg-transparent border-info text-center text-warning">Seçiminiz</div>
						<div class="card-body text-warning">
							<h2 class="text-center bg-success" v-if="secim1Secildi">Koşarak geldim.Vantilatörü açar mısın?</h2>
                            <h2 class="text-center bg-success" v-if="secim2Secildi">Rüzgar şiddetini arttırdı.</h2>
                            <h2 class="text-center bg-success" v-if="secim3Secildi">Yemek yapcağım ışığı açar mısın?</h2>
                            <h2 class="text-center bg-success" v-if="secim4Secildi">İşim bitti ışığı kapatabilirsin.</h2>
							<h2 class="text-center bg-success" v-if="secim5Secildi">Açım</h2>
						</div>
						<div class="card-footer bg-transparent border-info text-center">
							<button v-if="!isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSec @click="secTest">Metin Seç</button>
							<button v-if="isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSenSecTestEt @click="smartTest">Test Et</button>
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
								<h4 class="text-center">Koşarak geldim.Vantilatörü açar mısın?</h4>
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim1">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<h4 class="text-center">Rüzgar şiddetini arttırdı.</h4>
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim2">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<h4 class="text-center">Yemek yapcağım ışığı açar mısın?</h4>
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim3">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<h4 class="text-center">İşim bitti ışığı kapatabilirsin.</h4>
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim4">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<h4 class="text-center">Acıktım.</h4>
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim5">Seç</button>
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
		<div v-if="isSmartTest">
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
		<!-- Test -->
	</div>
</template>

<script>
import Board from "./DragDrop/Board"
import Card from "./DragDrop/Card"
export default {
    name:"AkıllıSınıf",
    components:{
        Board,
        Card
    },
    data(){
        return{
            isLoading: false,
            secenekler: true,
            isTrain: false,
            isSmartTrain: false,
            egitimSonu: "",
            veriOnIsleme: "",
            transformasyonu: "",
            egitimBaslangici: "",
            isEgitimBittiMi: false,
            isFireWorks: false, 
            isTest: false,
            isTestBittiMi: false,
            isSmartTest: false,
            veriTestBaslangıc: "",
            veriTestSon: "",
            testSonuc: "",
            isSecildiMi: false,
			onSec: false,
            secim1Secildi: false,
			secim2Secildi: false,
			secim3Secildi: false,
			secim4Secildi: false,
			secim5Secildi: false,
			tekSonuc: false,
            oyun: {"id":8,"image": require('@/assets/img/oyunlar/smart.png'),"zorluk": "Zorluk: Başlangıç","link":"/akıllısınıf","isim": "Akıllı Sınıf","icerik": "Scratch'da sanal cihazları kontrol etmenizi sağlayan bir akıllı asistan oluşturun. Bir bilgisayara komutlarınızın anlamını tanımasını sağlayın.",},
			resimler: {"openFan": require('@/assets/img/oyunlar/akilliSinif/openFan.gif'),"closeFan": require('@/assets/img/oyunlar/akilliSinif/closeFan.png'),"openLamb": require('@/assets/img/oyunlar/akilliSinif/openLamb.gif'),"closeLamb": require('@/assets/img/oyunlar/akilliSinif/closeLamb.png'),"hata": require('@/assets/img/oyunlar/akilliSinif/hata.gif'),},
			kartlar:[{"cardId":"card-5","icerik":"Bugün hava çok sıcak."},{"cardId":"card-6","icerik":"Yazdıklarımı göremiyorum."},{"cardId":"card-7","icerik":"Vantilatör bozulacak, kapatabiliriz."},{"cardId":"card-8","icerik":"Vantilatörü kapatır mısın?"},{"cardId":"card-9","icerik":"Odam yeterince aydınlık."},
				{"cardId":"card-10","icerik":"Hava 40 derece."},{"cardId":"card-11","icerik":"İçeri soğuk."},{"cardId":"card-12","icerik":"Kalemimi bulamıyorum ışığı açar mısın?"},{"cardId":"card-13","icerik":"Kedi üşüyor."},{"cardId":"card-14","icerik":"Yaz aylarında vantilatör hep açıktır."},{"cardId":"card-15","icerik":"Evde gelince lambaları aç."},
				{"cardId":"card-16","icerik":"Uyuyamıyorum vantilatörü kapatır mısın?"},{"cardId":"card-17","icerik":"Evden çıkarken ışıkları kapat."},{"cardId":"card-18","icerik":"Düşmemek için ışkları açmalısın."},{"cardId":"card-19","icerik":"Kıyafetlerin kurumasını için vantilatörü aç"},{"cardId":"card-20","icerik":"Film izlerken ışıkları kapatalım mı?"},
				{"cardId":"card-21","icerik":"Hareket edersen otomatik ışık açılır."},{"cardId":"card-22","icerik":"Ekmek fırınında vantilatör hep açıktır."},{"cardId":"card-23","icerik":"Mutfakta kimse yok ışığı kapatalım."},{"cardId":"card-24","icerik":"Işığı açarsan içerideki civcivleri görürsün."},]
        }
    },
    methods: {
        basla(){
            this.isLoading = true;
        },
        train(){
            this.secenekler = false;
            this.isTrain = true;
        },
        smartTrain(){
            this.veriOnIsleme = "";
            this.transformasyonu = "";
            this.egitimBaslangici = "";
            this.egitimSonu = "";
            this.isEgitimBittiMi = false;
            this.isSmartTrain = true;

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
            this.isSmartTrain = false;
			this.secenekler = true;
        },
        test(){
            this.secenekler = false;
            this.isTest = true;
            this.testSonuc = "";
            this.isTestBittiMi = false;
            this.secim1Secildi = false;
			this.secim2Secildi = false;
			this.secim3Secildi = false;
			this.secim4Secildi = false;
			this.secim5Secildi = false;
            this.isSecildiMi = false;
            this.onSec = false;
        },
        smartTest(){
            this.veriTestBaslangıc = "";
            this.veriTestSon = "";
            this.isSmartTest = true;
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
            this.isSmartTrain = false;
            this.secenekler = false;
            this.testSonuc = "Test Sonuçları";
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
		secim4(){
            this.isSecildiMi = true;
            this.secim4Secildi = true;
		},
		secim5(){
            this.isSecildiMi = true;
            this.secim5Secildi = true;
        },
        modalSenSecTestEt(){
            this.isLoading = true
            this.isTrain = false
            this.isSmartTrain = false;
            this.secenekler = false;
            this.isTest = false;
            this.testSonuc = "Test Sonucu";
            this.tekSonuc = true;
        }
    }
}
</script>

<style scoped>
*{
    margin :0;
    padding: 0;
    box-sizing: border-box;
}
body {
    background-color: #f3f3f3;
}
.flexbox {
    /*display: flex;*/
    justify-content: space-between;   
    width: 100%;
    max-width: 1000px;
    /*overflow: auto;*/
    margin: auto;
    padding: 10px;
}
.flexbox .board{
    display: flex;
    flex-direction:row;
    /*width: 100%;*/
    width: 1000px;
	height: fit-content;
    background-color: #313131;
    margin-top: 3px;
	margin-bottom: 3px;
	overflow-x: auto;
}
.flexbox .board .card{
    /*padding: flex;*/
	flex-direction:row;
    background-color: #f3f3f3;
    cursor: pointer;
	margin:10px;
	padding:5px;
	height:fit-content;
	overflow: hidden;
}
</style>