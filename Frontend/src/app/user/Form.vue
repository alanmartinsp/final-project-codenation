<template>
  <div class="text-center">
    <v-dialog
      persistent
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
          
        <v-form ref="form" v-model="view.valid" lazy-validation>
          <v-row dense>
              <v-col cols="12" sm="12">
                <v-text-field
                  dense
                  label="Nome"
                  outlined
                  v-model="model.name"
                  required
                  :rules="[view.rules.required]"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="12">
                <v-text-field
                  dense
                  label="Email"
                  outlined
                  v-model="model.email"
                  required
                  :rules="[view.rules.required]"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="12">
                <v-text-field
                  :append-icon="view.showIconPass ? 'mdi-eye' : 'mdi-eye-off'"
                  :rules="[view.rules.required, view.rules.min]"
                  :type="view.showIconPass ? 'text' : 'password'"
                  counter
                  @click:append="view.showIconPass = !view.showIconPass"
                  dense
                  label="Password"
                  outlined
                  v-model="model.password"
                ></v-text-field>
              </v-col>
          </v-row>
            </v-form>

        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            :loading="view.loading"
            text
            @click="onClickCancel">
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
        model: {
          name: '',
          email: '',
          password: ''
        },
        view: {
          valid: false,
          dialog: false,
          loading: false,
          showIconPass: false,
          rules: {
            required: value => !!value || 'Required.',
            min: v => (v || []).length >= 8 || 'Min 8 characters'
          },
        }
      }
    },

    mounted() {
    },

    methods: {
      onClickAdd() {
        if (!this.$refs.form.validate()) {
          return
        }

        this.view.loading = true
        http.post('user', this.model).then(() => {
          this.view.loading = false
          this.clear()
          this.view.dialog = false
          this.notify('Cadastro realizado com sucesso')
        })
      },

      clear() {
        this.$refs.form.reset()
      },

      onClickCancel() {
        this.clear()
        this.view.dialog = false
      },

      open() {
        this.view.dialog = true
      }
  }
}
</script>