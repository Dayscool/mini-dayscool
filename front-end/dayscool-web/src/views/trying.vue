<template>
<div>
    <link href='https://fonts.googleapis.com/css?family=Montserrat Alternates' rel='stylesheet'>
    <div id="top">
       
    </div>
    <div id=cuerpo>
        <h2>
            Mis Cursos
        </h2>
        <div id="lista">
            <Curso v-for="curso in cursos" v-bind:cursr="curso" v-bind:key = "curso.id" />
        </div>
        <div class = "boton">
            Cursos Anteriores
        </div>
    </div>
</div>
</template>

<script>
import Curso from "@/components/cours.vue";
const axios = require('axios');
export default {
    name: "cursos",
    components: {
        Curso
    },
    data () {
        return {
            cursos: null
        }
    },
    mounted() {
        console.log(this.$store.getters.returnUser);
        if (this.$store.getters.returnUser.role === null) {
            alert("no hay rol");
        } else if(this.$store.getters.returnUser.role == "Profesor") {
            axios.post(this.$store.state.backURL, {
                query: `
                    query getCursoById ($id: Int!){
                    getCursoById (id: $id) {
                        Id
                        nombre
                    }
                    }
                `,
                variables: {
                    id: this.$store.state.user.id
                }
            }).then(response => (this.cursos = response.data.data.getCursoStudentById))
        } else {
            axios.post(this.$store.state.backURL, {
                query: `
                    query getCursoStudentById($id: Int!){
                        getCursoStudentById(id: $id) {
                        Id
                        nombre
                    }
                    }
                `,
                variables: {
                    id: this.$store.state.user.id
                }
            }).then(response => (this.cursos = response.data.data.getCursoStudentById))
        }
    } 
}
</script>

<style>
div{
    font-family: Montserrat Alternates;
}
#cuerpo > h2 {
    font-family: inherit;
}
div#lista{ 
    display: flex;
    flex-direction: row ;
    flex-wrap: wrap;
    justify-content: flex-start;
    align-content: flex-start;
    padding: 0 15vw;
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
</style>