<template>
  <div>
    <v-app>
    <v-content>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <v-flex xs12 sm8 md4 lg4>
            <v-card class="elevation-2 pa-4">
              <v-card-text>
                <div class="layout column align-center pa-4">
                  <img :src="require('../../assets/logo.png')"/>
                </div>
                <v-form ref="form" v-model="view.valid" lazy-validation>
                  <v-text-field
                    dense
                    outlined
                    append-icon="mdi-account" 
                    name="login"
                    label="Email"
                    type="text" 
                    v-model="model.email"
                    required
                    :rules="[view.rules.required]"/>

                  <v-text-field
                    dense
                    outlined
                    append-icon="mdi-lock"
                    name="password"
                    label="Password"
                    id="password"
                    type="password"
                    v-model="model.password"
                    required
                    :rules="[view.rules.required]"/>
                </v-form>
              </v-card-text>

              <v-card-actions>
                <v-btn block color="primary" @click="login" :loading="view.loading.isLoading">Login</v-btn>
              </v-card-actions>
            </v-card>
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
  </v-app>
  </div>
</template>
<script>

import http from '@/plugins/http'

export default {

  name: 'Auth',

  props: {
  },

  components: {
  },

  data () {
    return {
      model: {
        username: '',
        password: '',
      },
      view: {
        valid: false,
        loading: {
          isLoading: false
        },
        rules: {
          required: value => !!value || 'Campo Obrigatório.'
        }
      }
    }
  },

  mounted () {
  },

  watch: {
  },

  computed: {
  },

  methods: {
    login () {
      if (!this.$refs.form.validate()) {
        return
      }

      this.view.loading.isLoading = true
      http.post('login', this.model).then(response => {
        let token = response.data.token
        let user = response.data.user
        this.setTokenLocalStorage(token, user)
        this.setTokenHearderHttp(token)
        this.$router.push('/')
      }).catch(ex => {
        let message = ex.response.data.error
        this.notify(message, 'error')
      }).then(() => {
        this.view.loading.isLoading = false
      })
    },

    setTokenHearderHttp (token) {
      http.defaults.headers.common['Authorization'] = 'Bearer ' + token
    },

    setTokenLocalStorage (token, user) {
      localStorage.setItem('token', token)
      localStorage.setItem('user', JSON.stringify(user))
    }
  }
}

</script>
