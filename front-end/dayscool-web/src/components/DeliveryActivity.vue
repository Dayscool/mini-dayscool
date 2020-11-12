<template>
  <div class="activity">
    <div class="container">
      <div class="divcont">
        <h3>Tarea Reciente</h3>
        <h6>Fecha de entrega: <span> 30 de octubre, 2020</span></h6>
        <form>
            <label >Nombre de entrega</label>
            <br/>
            <textarea v-model="message" placeholder="Nombre de entrega" required></textarea>
            <br/>
            <label >Descripción</label>
            <br/>
            <textarea v-model="message" placeholder="Descripción" required></textarea>
            <br/>
            <label >Archivos Adjuntos <input type="file"></label>
        </form>
        <button class="button button1">Confirmar Entrega</button>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "",
  data() {
    return {
        form:{

        }
    }
  },
  methods:{
  }
};
</script>

<style>

div.activity{ 
    width: 100%;
    margin: 0%;
    display: flex;
    align-content: center;
    align-items: center;
}
.container{
    width: 100%;
    text-align: center;
}
.divcont{
    width: 100%;
    max-width: 300px;
    background: rgba(255, 255, 255, 255);
    padding: 5%;
    border-radius: 10px;
    display: inline-block;
    box-shadow: 0 4px 10px 4px rgba(0, 0, 0, 0.3);
    border: 1px solid #707070;
}
textarea{
  width: 100%;
  padding: 12px 20px;
  margin: 10px 0;
  box-sizing: border-box;
  border-radius: 4px;
  border: 2px solid #ccc;
}
input{
    margin: .4rem 0;
}
h6{
    text-align: right;
}
form{
  text-align: left;
}
button {
  background-color: #4c87af; 
  border: none;
  border-radius: 4px;
  color: white;
  padding: 4% ;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 6px 16px;
  transition-duration: 0.4s;
  cursor: pointer;
}
.button1 {
  background-color: white; 
  color: black; 
  border: 1px solid #4c87af;
}
.button1:hover {
  background-color: #4c87af;
  color: white;
}
</style>