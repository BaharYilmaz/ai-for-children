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
                                <span class="badge badge-primary">Difficulty: Beginner</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="javascript:void(0)" class="text-body">Car or cup</a></h5>
                            <p class="text-muted mb-3">Train the computer to be able to sort photos into groups.Teach a computer to recognise pictures of objects</p>
                            
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
                                <span class="badge badge-primary">Difficulty: Beginner</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="javascript:void(0)" class="text-body">Chameleon</a></h5>
                            <p class="text-muted mb-3">Make a chameleon in Scratch that changes colour to match its background.Teach a computer to recognise colours</p>
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
                                <span class="badge badge-primary">Difficulty: Advanced</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="javascript:void(0)" class="text-body">Find It!</a></h5>
                            <p class="text-muted mb-3">Make a hide-and-seek game for your mobile phone.Teach a computer to recognise pictures</p>
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
                                <span class="badge badge-primary">Difficulty: Beginner</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="javascript:void(0)" class="text-body">Kiwi or Stoat</a></h5>
                            <p class="text-muted mb-3">Make a project in Scratch that can recognize animals in photos from conservation sites.Teach a computer to recognize photos of animals</p>
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
                                <span class="badge badge-primary">Difficulty: Beginner</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="javascript:void(0)" class="text-body">Make me happy</a></h5>
                            <p class="text-muted mb-3">Create a character in Scratch that smiles if you say nice things to it and cries if you say mean things to it.Teach a computer to recognise compliments and insults</p>
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
                                <span class="badge badge-primary">Difficulty: Intermediate</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="javascript:void(0)" class="text-body">School Library</a></h5>
                            <p class="text-muted mb-3">Create a school librarian in Scratch that suggests who a reading book might be suitable for.Teach a computer to make recommendations</p>
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
                                <span class="badge badge-primary">Difficulty: Beginner</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="javascript:void(0)" class="text-body">Smart Classroom</a></h5>
                            <p class="text-muted mb-3">Create a smart assistant in Scratch that lets you control virtual devices.Teach a computer to recognise the meaning of your commands</p>
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
                                <span class="badge badge-primary">Difficulty: Intermediate</span>
                                </div>
                            </div>
                            </a>
                        </div>
                        <div class="card-body">
                            <h5 class="mb-3"><a href="javascript:void(0)" class="text-body">Sorting Hat</a></h5>
                            <p class="text-muted mb-3">Create a Sorting Hat like in Harry Potter, that puts you in a school House based on what you say.Teach a computer to recognise use of language</p>
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
          backgroundImage:`url(${require('@/assets/img/oyunlar/arabaKupa2.jpg')})`
        },
        cssBukalemun:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/bukalemun.jpg')})`
        },
        cssFind:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/findit.jpg')})`
        },
        cssKivi:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/kiviGelincik2.jpg')})`
        },
        cssHappy:{
          backgroundImage:`url(${require('@/assets/img/oyunlar/mutlu.gif')})`
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