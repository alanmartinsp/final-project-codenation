<template>
  <v-main>
  
    <v-card-title>

      <v-row>
        <v-col cols="12" md="2">
          <v-select
          :items="view.list.enviroments"
          label="Ambiente"
          v-model="view.filter.enviroment"
          dense
          outlined
          item-text="description"
          item-value="value"
          clearable
        />
        </v-col>
        <v-col cols="12" md="2">
          <v-select
          :items="view.list.orderBy"
          label="Ordenar por"
          v-model="view.filter.orderBy"
          dense
          outlined
          item-text="description"
          item-value="value"
          clearable
        />
        </v-col>
        <v-col cols="12" md="2">
          <v-select
          :items="view.list.typeFiltes"
          label="Buscar por"
          v-model="view.filter.filter"
          dense
          outlined
          item-text="description"
          item-value="value"
          clearable
        />
        </v-col>

        <v-col cols="12" md="4" v-if="view.filter.filter == 'level'">
          <v-select
          :items="view.list.levels"
          label="Level"
          v-model="view.filter.description"
          dense
          outlined
          item-text="description"
          item-value="value"
          clearable
        />
        </v-col>

        <v-col cols="12" md="4" v-else>
          <v-text-field
            :disabled="!view.filter.filter"
            dense
            label="Digite aqui"
            outlined
            v-model="view.filter.description"
          />
        </v-col>

        <v-col cols="12" md="2" class="text-right">          
        <v-btn tile color="primary" @click="filter">
            <v-icon left>mdi-text-box-search-outline</v-icon>
            Buscar
          </v-btn>
        </v-col>
      </v-row>

       
      
    </v-card-title>
    <v-data-table
      :headers="view.headers"
      :items="view.list.logs"
      :loading="view.loading">
      
      <template v-slot:item.level="{item}">
        <v-chip
          class="ma-2">
          {{ getLevelDescription(item.level) }}
        </v-chip>
      </template>

      <template v-slot:item.enviroment="{item}">
          {{ getEnviromentDescription(item.enviroment) }}
      </template>

      <template v-slot:item.log="{item}">
        <div class="text-center">
          <span>{{item.details}}</span><br>
          <span>{{item.origin}}</span><br>
          <span>{{formatDate(item.createAt)}}</span>
        </div>
      </template>

      <template v-slot:item.actions="{item}">
        <div class="my-2 text-right">
            <v-btn icon @click="onClickView(item)">
              <v-icon>mdi-eye</v-icon>
            </v-btn>

            <v-btn icon>
              <v-icon>mdi-delete</v-icon>
            </v-btn>
          </div>
      </template>

    </v-data-table>
  
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
          loading: false,
          filter: {},
          list: {
            logs: [],
            enviroments: [
              { value: 1, description: 'Produção' },
              { value: 2, description: 'Homologação' },
              { value: 3, description: 'Dev' },
            ],
            orderBy: [
              { value: 'level', description: 'Level' },
              { value: 'level', description: 'Freguência' }
            ],
            typeFiltes: [
              { value: 'level', description: 'Level' },
              { value: 'title', description: 'Descrição' },
              { value: 'origin', description: 'Origem' },
            ],
            levels: [
              { value: 1, description: 'Error' },
              { value: 2, description: 'Warning' },
              { value: 3, description: 'Debug' },
            ]
          },
          headers: [
            {
              text: 'Ambiente',
              align: 'start',
              sortable: false,
              value: 'enviroment',
              width: 10
            },
            {
              text: 'Level',
              align: 'start',
              sortable: false,
              value: 'level',
              width: 10
            },
            { text: 'Log', align: 'center', value: 'log' },
            { text: 'Eventos', value: 'event', width: 10 },
            { text: '', value: 'actions' }
          ]
        }
      }
    },

    mounted() {
      this.filter()
    },

    watch: {
      'view.filter.filter'() {
        this.view.filter.description = ''
      }
    },
    methods: {
      filter() {
        let route = this.mounteParams()
        this.view.loading = true
        http.get(`log${route}`).then(response => {
          this.view.list.logs = response.data
          this.view.loading = false
        })
      },
      mounteParams() {
        let paramsFilter = []
        if (this.view.filter.enviroment) {
          paramsFilter.push(`enviroment=${this.view.filter.enviroment}`)
        }

        if (this.view.filter.orderBy) {
          paramsFilter.push(`orderBy=${this.view.filter.orderBy}`)
        }

        if (this.view.filter.filter) {
          paramsFilter.push(`field=${this.view.filter.filter}`)
        }

        if (this.view.filter.description) {
          paramsFilter.push(`fieldDescription=${this.view.filter.description}`)
        }

        let route = '';
        if(paramsFilter.length > 0) {
          route += `?${paramsFilter.join('&')}`
        }

        return route
      },
      onClickView(item) {
        this.$router.push(`/log/${item.id}`)
      },
      onClickDelete(item) {
        http.get(`log/${item.id}`).then(() => {
          this.filter()
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
      getEnviromentDescription(enviroment) {
        let log = (this.view.list.enviroments.find(e => e.value == enviroment))
        if (log)
          return log.description
        
        return 'N/A'
      }
    }
  }
</script>