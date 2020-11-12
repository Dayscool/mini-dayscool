<template>
  <div class="curso">
      <span>{{cursr.nombre}}</span>
      <br>
    </div>
</template>

<script>
export default {
    name: "Curso",
    props: {
        cursr: cursoInfo
    }
}
var cursoInfo = {
    id: Number,
    nombre: String
}
</script>

<style>
div.curso{
    
    margin: 1.5vmax 1vw;
    font-size: medium;
    border: 1px solid #707070;
    border-radius: 14px;
    width: 46%;
    height: 16vh;
    padding: 3%;
    box-sizing: border-box;
    line-height: 4vmin;
    text-align: left;
}
.curso > span{
    font-size: x-large;
    color: #4191E0;
    line-height: 20px;
}
</style>