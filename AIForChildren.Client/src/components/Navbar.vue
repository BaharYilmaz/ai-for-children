<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-success">
        <a class="navbar-brand" href="/">Anasayfa</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar-example-7">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbar-example-7">
            <div class="navbar-nav ml-auto">
            <!--<a class="nav-item nav-link active" href="/">Home</a>-->
            <a class="nav-item nav-link" href="/login">Giriş Yap |</a>
            <a class="nav-item nav-link" href="/register">Kayıt Ol |</a>
            </div>

        </div>
    </nav>

</template>

<script>
export default {
    name:"navbar"
}
</script>