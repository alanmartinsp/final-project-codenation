<template>
  <div class="text-center">
    <v-dialog
      v-model="view.dialog"
      width="700"
    >
      <v-card>
        <v-card-title>
          Novo Usuário
        </v-card-title>

        <v-divider></v-divider>
        <br>
        <v-card-text>
          
          <v-row dense>
            <v-col cols="12" sm="12">
              <v-text-field
                dense
                label="Nome"
                outlined
                v-model="model.name"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="12">
              <v-text-field
                dense
                label="Email"
                outlined
                v-model="model.email"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="12">
              <v-text-field
                dense
                label="Password"
                outlined
                v-model="model.password"
              ></v-text-field>
            </v-col>
          </v-row>

        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            :loading="view.loading"
            text
            @click="view.dialog = false">
            Cancelar
          </v-btn>
          <v-btn
            :loading="view.loading"
            text
            @click="onClickAdd">
            Salvar
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>

  import http from '@/plugins/http'

  export default {

    data () {
      return {
        model: {},
        view: {
          dialog: false,
          loading: false
        }
      }
    },

    mounted() {
    },

    methods: {
      onClickAdd() {
        this.view.loading = true
        http.post('user', this.model).then(() => {
          this.view.loading = false
          this.view.dialog = false
          this.notify('Cadastro realizado com sucesso')
        })
      },

      open() {
        this.view.dialog = true
      }
  }
}
</script>