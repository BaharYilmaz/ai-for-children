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
            <page-head icon="play-fill" title="Araba veya Kupa" />
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
            <b-button class="mt-2 mb-2" block variant="success"><b>Makineye nesneleri öğretelim. Seçtiğiniz resimler mümkün olduğunca birbirinden farklı olsun.</b></b-button>
                <div class="row justify-content-center">
                    <!-- Mutlu -->
                    <div class="card border-info mb-3 bg-dark col-md-2 ml-2 mr-2 mt-2" v-for="(renk, index) in carOrCup" :key="index">
                        <div class="form-group btn-sm btn-success mt-2">
                            <select class="form-control btn-success " id="sel1">
                                <option>Seçiniz</option>
                                <option>Araba</option>
                                <option>Kupa</option>
                            </select>
                        </div>
                        
                        <div class="card-body text-warning">
                            <img :src=renk class="img-thumbnail">
                        </div>
                    </div>
                </div>
                
                <div class="text-center">
                    <b-button block variant="success" class="text-dark" v-b-modal.modalEgit @click="RenkTrain">Tümünü Eğit</b-button>
                </div>
            </div>
            <!-- ModalsTrain -->
            <div v-if="isRenkTrain">
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
                            <img v-if="secim1Secildi" :src=resimler.testCup alt="testCup" class="img-thumbnail">
                            <img v-if="secim2Secildi" :src=resimler.testCar2 alt="testCar2" class="img-thumbnail">
                            <img v-if="secim3Secildi" :src=resimler.testCar alt="testCar" class="img-thumbnail">
                            <img v-if="secim4Secildi" :src=resimler.testCup2 alt="testCup2" class="img-thumbnail">
                        </div>
                    </div>
                    <div class="text-center" v-if="tekSonuc">
                        <h2 class="text-center bg-success" v-if="secim1Secildi">Kupa</h2>
                        <h2 class="text-center bg-success" v-if="secim2Secildi">Araba</h2>
                        <h2 class="text-center bg-success" v-if="secim3Secildi">Araba</h2>
                        <h2 class="text-center bg-success" v-if="secim4Secildi">Kupa</h2>
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
                    <h3 v-if="!tumSonuclar" class="text-center bg-info">SEÇTİĞİN RESMİ TEST EDEBİLİRİZ</h3>
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
                            <img v-if="secim1Secildi" :src=resimler.kupa1 alt="kupa" class="img-thumbnail">
                            <img v-if="secim2Secildi" :src=resimler.car1 alt="araba" class="img-thumbnail">
                            <img v-if="secim3Secildi" :src=resimler.car2 alt="araba" class="img-thumbnail">
                            <img v-if="secim4Secildi" :src=resimler.kupa2 alt="kupa" class="img-thumbnail">
                        </div>
                        <div class="card-footer bg-transparent border-info text-center">
                            <button v-if="!isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSec
                                    @click="secTest">Resim Seç</button>
                            <button v-if="isSecildiMi" class="btn btn-outline-info text-warning" v-b-modal.modalSenSecTestEt
                                    @click="RenkTest">Test Et</button>
                        
                        </div>
                    </div>
                </div>
                <!--
                <div v-if="tumSonuclar" class="text-center bg-success mt-3 mb-3">
                    <fireworks></fireworks>
                </div>-->
                <div v-if="tumSonuclar" class="text-center mt-5 mb-5 fixed-bottom">
                    <p>Tekrar oynamak için sayfayı yenileyin!</p>
                    <router-link to="/">Anasayfa</router-link>
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
                                <img :src=resimler.kupa1 alt="kırmızı" class="img-thumbnail">
                                <div class="text-center mt-3 mb-3">
                                    <button v-if="!isSecildiMi" class="btn btn-success" @click="secim1">Seç</button>
                                </div>
                            </div>
                            <div class="col-md-3 ml-5 mr-5">
                                <img :src=resimler.car1 alt="sarı" class="img-thumbnail">
                                <div class="text-center mt-3 mb-3">
                                    <button v-if="!isSecildiMi" class="btn btn-success" @click="secim2">Seç</button>
                                </div>
                            </div>
                            <div class="col-md-3 ml-5 mr-5">
                                <img :src=resimler.car2 alt="yeşil" class="img-thumbnail">
                                <div class="text-center mt-3 mb-3">
                                    <button v-if="!isSecildiMi" class="btn btn-success" @click="secim3">Seç</button>
                                </div>
                            </div>
                            <div class="col-md-3 ml-5 mr-5">
                                <img :src=resimler.kupa2 alt="mavi" class="img-thumbnail">
                                <div class="text-center mt-3 mb-3">
                                    <button v-if="!isSecildiMi" class="btn btn-success" @click="secim4">Seç</button>
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
        <div v-if="isRenkTest">
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
    </div>
</template>

<script>
    export default {
        
        data(){
            return{
                name:"Araba veya Kupa",
                isLoading: false,
                secenekler: true,
                isTrain: false,
                isRenkTrain: false,
                egitimSonu: "",
                veriOnIsleme: "",
                transformasyonu: "",
                egitimBaslangici: "",
                isEgitimBittiMi: false,
                isFireWorks: false,
                isTest: false,
                isTestBittiMi: false,
                isRenkTest: false,
                veriTestBaslangıc: "",
                veriTestSon: "",
                testSonuc: "",
                isSecildiMi: false,
                onSec: false,
                secim1Secildi: false,
                secim2Secildi: false,
                secim3Secildi: false,
                secim4Secildi: false,
                tumSonuclar: false,
                tekSonuc: false,
                carOrCup: [require("@/assets/img/oyunlar/carorcup/1.jpg"),require("@/assets/img/oyunlar/carorcup/17.jpg"),require("@/assets/img/oyunlar/carorcup/3.jpg"),require("@/assets/img/oyunlar/carorcup/11.jpg"),require("@/assets/img/oyunlar/carorcup/6.jpg"),require("@/assets/img/oyunlar/carorcup/7.jpg"),require("@/assets/img/oyunlar/carorcup/20.jpg"),require("@/assets/img/oyunlar/carorcup/8.jpg"),require("@/assets/img/oyunlar/carorcup/19.jpg"),require("@/assets/img/oyunlar/carorcup/2.jpg"),require("@/assets/img/oyunlar/carorcup/9.jpg"),require("@/assets/img/oyunlar/carorcup/10.jpg"),require("@/assets/img/oyunlar/carorcup/12.jpg"),require("@/assets/img/oyunlar/carorcup/13.jpg"),require("@/assets/img/oyunlar/carorcup/14.jpg"),require("@/assets/img/oyunlar/carorcup/4.jpg"),require("@/assets/img/oyunlar/carorcup/15.jpg"),require("@/assets/img/oyunlar/carorcup/5.jpg"),require("@/assets/img/oyunlar/carorcup/16.jpg"),require("@/assets/img/oyunlar/carorcup/18.jpg")],
                oyun: {"id":1,"image": require('@/assets/img/oyunlar/araba.jpg'),"zorluk": "Zorluk: Başlangıç","link":"/arabaveyakupa","isim": "Araba veya Kupa","icerik": "Fotoğrafları gruplara ayırabilmek için bilgisayarı eğitin. Daha sonra Nesneleri nasıl tanıdığımızı görmek için test edin."},
                resimler:{"car1":require("@/assets/img/oyunlar/carorcup/Car/car5.jpg"),"car2":require("@/assets/img/oyunlar/carorcup/Car/car7.jpg"),"kupa1":require("@/assets/img/oyunlar/carorcup/Cup/cup3.jpg"),"kupa2":require("@/assets/img/oyunlar/carorcup/Cup/cup6.jpg"),"testCup":require("@/assets/img/oyunlar/carorcup/cupAll1.jpg"),"testCup2":require("@/assets/img/oyunlar/carorcup/cupAll2.jpg"),"testCar":require("@/assets/img/oyunlar/carorcup/carAll1.jpg"),"testCar2":require("@/assets/img/oyunlar/carorcup/carAll2.jpg")},
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
            RenkTrain(){
                this.veriOnIsleme = "";
                this.transformasyonu = "";
                this.egitimBaslangici = "";
                this.egitimSonu = "";
                this.isEgitimBittiMi = false;
                this.isRenkTrain = true;
                
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
                this.isRenkTrain = false;
                this.secenekler = true;
            },
            test(){
                this.secenekler = false;
                this.isTest = true;
                this.testSonuc = "";
                this.isTestBittiMi = false;
                this.secim1Secildi = false;
                this.secim2Secildi = false;
                this.isSecildiMi = false;
                this.onSec = false;
            },
            RenkTest(){
                this.veriTestBaslangıc = "";
                this.veriTestSon = "";
                this.isRenkTest = true;
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
                this.isRenkTrain = false;
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
            secim4(){
                this.isSecildiMi = true;
                this.secim4Secildi = true;
            },
            modalSenSecTestEt(){
                this.isLoading = true
                this.isTrain = false
                this.isRenkTrain = false;
                this.secenekler = false;
                this.isTest = false;
                this.testSonuc = "Test Sonucu";
                this.tekSonuc = true;
            }
        }
    }
</script>