<template>
  <div>
  <h3>Example 4</h3>

  <div>
    Data:
    {{ champions }}
  </div>
  <button @click="getChampionByName">Prueba </button>
  <button @click="createNotification">Crear </button>
  </div>
</template>

<script>
import axios from 'axios'
export default {
    name: "Prueba.vue",
  data () {
    return { 
      /* ... */ 
      champions: {}
    }
  },
methods: {
    /* ... */
     async getChampionByName () {
      const res = await axios.post(
        'http://localhost:5000/graphql', {
        query: `
          query getAllNotifications($userId: Int!) {
            getAllNotifications(userId: $userId) {
                _id
                userId
                date
                message
            }
          }`,
          variables: {
            userId: '1'
          },
      })
      this.champions = res.data.data.getAllNotifications;
      console.log(res.data.data.getAllNotifications);
    },
    async createNotification () {
        const res = await axios.post('http://localhost:5000/graphql', {
        query: `
          mutation createNotification($notification: NotificationInput!){
          createNotification(notification: $notification) {
            userId
            conversationId		
            message
            senderId
          }
        }`,
        variables: {
            notification:{ userId: 3,
            conversationId: 2,
            message:"Dios que sirva please",
            senderId: 4}
        }
        })
        this.updatedChampion = res.data.data.createNotification;
        console.log(res.data.data.createNotification);
    }
  }
}
</script>