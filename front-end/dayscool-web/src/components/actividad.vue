<template>
    <div class="actividad">
        <span>{{activity.name}}</span><br>
        {{activity.date}}
    </div>
</template>

<script>
export default {
    name: "Actividad",
    props: {
        activity: actividadInfo
    }
}
var actividadInfo = {
    name: String,
    date: String
}
</script>

<style>
div.actividad{
    margin: 2vh auto;
    font-size: medium;
    border: 1px solid #707070;
    border-radius: 14px;
    width: 48%;
    height: 17vh;
    padding: 3%;
    box-sizing: border-box;
    line-height: 4vmin;
    text-align: left;
}
.actividad > span{
    font-size: x-large;
    color: #4191E0;
    line-height: 20px;
}
</style>