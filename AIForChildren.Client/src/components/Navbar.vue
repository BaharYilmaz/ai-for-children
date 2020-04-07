<template>
    <nav class="navbar navbar-expand-lg bg-primary">
        <a class="navbar-brand" href="/">Home</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar-example-7">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbar-example-7">
            <div class="navbar-nav mr-auto">
            <!--<a class="nav-item nav-link active" href="/">Home</a>-->
            <a class="nav-item nav-link" href="/login">Login</a>
            <a class="nav-item nav-link" href="/register">Register</a>
            </div>

            <span class="navbar-text">
                AI4K
            </span>
        </div>
    </nav>

</template>

<script>
export default {
    name:"navbar"
}
</script>