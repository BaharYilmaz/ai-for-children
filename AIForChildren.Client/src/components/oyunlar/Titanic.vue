<template>
    <div class="container-fluid flex-grow-1 container-p-y">
		<div v-if="!isLoading">
			<page-head icon="play-fill" title="Başla" />
			<div class="text-center">
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
							</div>
							<!-- Layout content -->
						</div>
						<!-- / Layout container -->
					</div>
					<!-- Overlay -->
				</div>
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
				<b-button class="mt-2 mb-2" block variant="warning"><b>İpucu!! Titanic battığında 1. kattaki herkes ölmüştü. Orta kattaki insanlardan sadece kadınlar kurtuldu.Çünkü kadın ve çocuklara öncelik tanınmıştı. En üst kattan iser herkes başarıyla kurtulmuştu.Bu bilgiler doğrultusunda makinemize insanların bulunduğu kat ve cinsiyetine göre yaşayıp yaşamadığını öğretelim.</b></b-button>
				<b-button class="mt-2 mb-2" block variant="info"><b>İpucu!! Kırmızı butonlar ölü insanları temsil etmektedir. Yeşiller ise  kurtulanları. Sürükle bırak sayeseinde gerekli katlara yerleştirelim. </b></b-button>
				<b-button class="mt-2 mb-2" block variant="danger"><b>İpucu!! Unutmayın her katta 2 kadın ve 2 erkek bulunmaktadır. Eksik olmasın. :)</b></b-button>
				<main class="flexbox" v-bind:style="{ 'width': '100%'}">
                    <Board id="board-1">
                        <Card id="card-1" draggable="true" v-bind:style="{ 'background-color': 'red'}">
                            <p>KADIN</p>
                        </Card>
                        <Card id="card-2" draggable="true" v-bind:style="{ 'background-color': 'red'}">
                    		<p>ERKEK</p>
                        </Card>
						<Card id="card-3" draggable="true" v-bind:style="{ 'background-color': 'red'}">
                            <p>KADIN</p>
                        </Card>
                        <Card id="card-4" draggable="true" v-bind:style="{ 'background-color': 'red'}">
                            <p>ERKEK</p>
                        </Card>
						<Card id="card-8" draggable="true" v-bind:style="{ 'background-color': 'lightgreen'}">
                            <p>KADIN</p>
                        </Card>
						<Card id="card-9" draggable="true" v-bind:style="{ 'background-color': 'lightgreen'}">
                            <p>ERKEK</p>
                        </Card>
                        <Card id="card-10" draggable="true" v-bind:style="{ 'background-color': 'lightgreen'}">
                            <p>ERKEK</p>
                        </Card>
                        <Card id="card-11" draggable="true" v-bind:style="{ 'background-color': 'lightgreen'}">
                            <p>KADIN</p>
                        </Card>
                    </Board>
				</main>
				<main class="flexbox">
					<div class="col-3">
						<b-button class="mt-2 mb-2" block variant="warning"><b>KAT 1</b></b-button>
					</div>
					<div class="col-9">
						<Board id="board-2">
							<Card id="card-5" draggable="true" v-bind:style="{ 'background-color': 'red'}">
                            	<p>ERKEK</p>
                        	</Card>
						</Board>
					</div>
				</main>
				<main class="flexbox">
					<div class="col-3">
						<b-button class="mt-2 mb-2" block variant="warning"><b>KAT 2</b></b-button>
					</div>
					<div class="col-9">
						<Board id="board-3">
							<Card id="card-6" draggable="true" v-bind:style="{ 'background-color': 'red'}">
								<p>ERKEK</p>
							</Card>
							<Card id="card-7" draggable="true" v-bind:style="{ 'background-color': 'lightgreen'}">
								<p>KADIN</p>
							</Card>
						</Board>
					</div>
				</main>
				<main class="flexbox">
					<div class="col-3">
						<b-button class="mt-2 mb-2" block variant="warning"><b>KAT 3</b></b-button>
					</div>
					<div class="col-9">
						<Board id="board-4">
							<Card id="card-12" draggable="true" v-bind:style="{ 'background-color': 'lightgreen'}">
                           		<p>KADIN</p>
                        	</Card>
						</Board>
					</div>	
                </main>

				<div class="text-center">
					<b-button block variant="success" class="text-dark" v-b-modal.modalEgit @click="titanicTrain">Eğit</b-button>
				</div>

			</div>
			<!-- ModalsTrain -->
			<div v-if="isTitanicTrain">
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
							<img v-if="secim1Secildi" :src=oyun.test1 alt="test1" class="img-thumbnail">
							<img v-if="secim2Secildi" :src=oyun.test2 alt="test1" class="img-thumbnail">
							<img v-if="secim3Secildi" :src=oyun.test3 alt="test1" class="img-thumbnail">
							<img v-if="secim4Secildi" :src=oyun.test4 alt="test1" class="img-thumbnail">
						</div>
					</div>
					<div class="text-center" v-if="tekSonuc">
						<h2 class="text-center bg-success" v-if="secim1Secildi">ÖLEN KADIN</h2>
						<h2 class="text-center bg-success" v-if="secim2Secildi">ÖLEN ERKEK</h2>
						<h2 class="text-center bg-success" v-if="secim3Secildi">YAŞAYAN ERKEK</h2>
						<h2 class="text-center bg-success" v-if="secim4Secildi">YAŞAYAN KADIN</h2>
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
					<h3 v-if="!tumSonuclar" class="text-center bg-info">İSTERSEN SENİN SEÇTİĞİN RESMİ TEST EDEBİLİRİZ</h3>
				</div>
				<div v-if="!isSecildiMi" class="text-center">
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
							<img v-if="secim1Secildi" :src=oyun.test1 alt="test1" class="img-thumbnail">
							<img v-if="secim2Secildi" :src=oyun.test2 alt="test1" class="img-thumbnail">
							<img v-if="secim3Secildi" :src=oyun.test3 alt="test1" class="img-thumbnail">
							<img v-if="secim4Secildi" :src=oyun.test4 alt="test1" class="img-thumbnail">
						</div>
						<div class="card-footer bg-transparent border-info text-center">
							<button v-if="!isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSec @click="secTest">Resim Seç</button>
							<button v-if="isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSenSecTestEt @click="titanicTest">Test Et</button>
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
								<img :src=oyun.test1 class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim1">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<img :src=oyun.test2 class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim2">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<img :src=oyun.test3 class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim3">Seç</button>
								</div>
							</div>
							<div class="col-md-3 ml-5 mr-5">
								<img :src=oyun.test4 class="img-thumbnail">
								<div class="text-center mt-3 mb-3">
									<button v-if="!isSecildiMi" class="btn btn-primary" @click="secim4">Seç</button>
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
		<div v-if="isTitanicTest">
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
    name:"Titanic",
    components:{
        Board,
        Card
    },
    data(){
        return{
            isLoading: false,
            secenekler: true,
            isTrain: false,
            isTitanicTrain: false,
            egitimSonu: "",
            veriOnIsleme: "",
            transformasyonu: "",
            egitimBaslangici: "",
            isEgitimBittiMi: false,
            isFireWorks: false, 
            isTest: false,
            isTestBittiMi: false,
            isTitanicTest: false,
            veriTestBaslangıc: "",
            veriTestSon: "",
            testSonuc: "",
            isSecildiMi: false,
			onSec: false,
            secim1Secildi: false,
			secim2Secildi: false,
			secim4Secildi: false,
            secim3Secildi: false,
			tekSonuc: false,
			oyun: {"id":9,"image": require('@/assets/img/oyunlar/titanic.jpg'),"test1": require('@/assets/img/oyunlar/titanic/1.png'),"test2": require('@/assets/img/oyunlar/titanic/2.png'),"test3": require('@/assets/img/oyunlar/titanic/3.png'),"test4": require('@/assets/img/oyunlar/titanic/4.png'),"zorluk": "Zorluk: Başlangıç","link":"/titanic","isim": "Titanic","icerik": "Titanik'in batmasıyla kimin hayatta kalacağını tahmin edebilecek bir Python programı oluşturun.Bir bilgisayara sonuçları tahmin etmesini öğretin."},
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
        titanicTrain(){
            this.veriOnIsleme = "";
            this.transformasyonu = "";
            this.egitimBaslangici = "";
            this.egitimSonu = "";
            this.isEgitimBittiMi = false;
            this.isTitanicTrain = true;

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
            this.isTitanicTrain = false;
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
            this.isSecildiMi = false;
            this.onSec = false;
        },
        titanicTest(){
            this.veriTestBaslangıc = "";
            this.veriTestSon = "";
            this.isTitanicTest = true;
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
            this.isTitanicTrain = false;
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
        modalSenSecTestEt(){
            this.isLoading = true
            this.isTrain = false
            this.isTitanicTrain = false;
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
    display: flex;
    justify-content: space-between;   
    width: 100%;
    max-width: 1000px;
    overflow: hidden;
    margin: 0 auto;
    padding: 15px;
}
.flexbox .board{
    display: flex;
    flex-direction:row;
    width: 100%;
    max-width: 1000px;
    background-color: #313131;
    margin: 10px;
}
.flexbox .board .card{
    padding: flex;
    background-color: #f3f3f3;
    cursor: pointer;
	margin:10px;
	padding:5px;
}
</style>