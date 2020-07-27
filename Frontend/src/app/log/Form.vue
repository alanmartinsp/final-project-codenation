<template>
  <v-main class="container-log">
    
    <v-btn tile color="primary" text @click="onClickBack">
      Voltar
    </v-btn>

    <v-row>
      <v-col cols="12" md="12">
        <h1 class="text-center">
          Erro no {{ model.origin }} em {{ formatDate(model.createAt) }}
        </h1>
      </v-col>
aaaaa
      <v-col cols="12" md="8">
        
        <div class="container-title">
          <div><label><strong>Título</strong></label></div>
          <div><label>{{model.title}}</label></div>
        </div>

        <div class="container-details">
          <div><label><strong>Detalhes</strong></label></div>
          <div><label>{{model.details}}</label></div>
        </div>

      </v-col>
      <v-col cols="12" md="4">
        <v-chip
          class="ma-2">
          {{ getLevelDescription(model.level) }}
        </v-chip>
        <br>
        <div><label><strong>Eventos</strong>:</label></div>
        <div><label>{{ model.event }}</label></div>

        <div><label><strong>Coletado por:</strong></label></div>
        <div><label>{{ (model.user || {}).name }}</label></div>
      </v-col>

    </v-row>  
  </v-main>
</template>
<script>

import http from '@/plugins/http'
import moment from 'moment'

export default {

  data () {
    return {
      model: {},
      view: {
        breadcrumbs: [
          {
            text: 'Logs',
            disabled: false,
            href: 'log',
          },
        ]
      }
    }
  },

  mounted() {
    let logId = this.$route.params.id
    this.get(logId)
  },

  methods: {
    get(id) {
      http.get(`log/${id}`).then(response => {
        this.model = response.data
      })
    },
    formatDate(date) {
      return moment(date).format('DD/MM/YYYY HH:MM')
    },
    getLevelDescription(level) {
      if (level == 1)
        return 'Error'
      else if (level == 2)
        return 'Warning'
      else 
        return 'Debug'
    },
    onClickBack() {
      this.$router.replace('/log/')
    }
  }
}
</script>

<style scoped>

.container-log {
  padding: 25px;
}

.container-details {
  margin-top: 15px;
}

</style>