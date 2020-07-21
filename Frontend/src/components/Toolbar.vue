<template>
  <v-toolbar
    max-height="60"
    color="primary"
    fixed
    dark>
    <v-toolbar-title>CodenationLog</v-toolbar-title>

    <v-spacer/>

    <v-list color="primary" v-show="isLogged">
      <v-list-item>
        <v-list-item-content class="text-right">
          <v-list-item-title>{{ username }}</v-list-item-title>
          <v-list-item-subtitle><a @click="onClickSignOut" style="color:white;">Sair</a></v-list-item-subtitle>
        </v-list-item-content>

        <v-list-item-avatar>
          <img src="../assets/avatar.png">
        </v-list-item-avatar>
      </v-list-item>
    </v-list>
  </v-toolbar>
</template>
<script>
export default {

  data () {
    return {
      model: {},
      view: {}
    }
  },

  computed: {
    username() {
      let user = this.getUserLocalStorage()
      return user.name
    },
    isLogged() {
      return this.getUserLocalStorage() != undefined && this.getUserLocalStorage() != null
    }
  },

  methods: {
    onClickSignOut() {
      localStorage.clear()
      this.$router.replace({ path: '/auth' })
    },
    getUserLocalStorage() {
      return JSON.parse(localStorage.getItem('user'))
    }
  }
}
</script>
