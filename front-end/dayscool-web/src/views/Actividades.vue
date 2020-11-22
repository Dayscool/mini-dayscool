<template>
  <div>
      <link href='https://fonts.googleapis.com/css?family=Montserrat Alternates' rel='stylesheet'>
      <div id="cuerpo">
        <h2>Clase de los Jueves</h2>
    </div>
    <div id = "listaA">
        <Actividad v-bind:activity="{name: 'gato', date: 'ocelote'}"/>
    </div>
  </div>
</template>

<script>
import Actividad from "@/components/actividad.vue"; 
export default {
    name: "actividades",
    components: {
        Actividad
    }
}

</script>

<style>
div{
    font-family: Montserrat Alternates;
}

#cuerpo > h2 {
    width: fit-content;
    margin-left: auto;
    margin-right: auto;
    color: black;
    margin-bottom: 4vh;
}
div.boton{
    background-color: #4191E0;
    padding: 1%;
    width: fit-content;
    height: fit-content;
    justify-content: center;
    margin: 0 auto;
    margin-top: 4vh;
    color: #FFFFFF;
    border-radius: 8px;
}
div#listaA{
    display: flex;
    flex-direction: column ;
    align-content: flex-start;
}
</style>