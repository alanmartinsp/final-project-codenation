<template>
  <div id="appRoot">
    <v-app id="inspire" class="app">
      <template v-if="!$route.meta.public">
        <AppBar/>
        <v-content padding="5px">
          <v-card height="100%">
            <router-view/>
          </v-card>
        </v-content>
      </template>
      <template v-else>
      <transition>
        <keep-alive>
          <router-view></router-view>
        </keep-alive>
      </transition>
    </template>

    <Notification/>
    </v-app>
  </div>
</template>

<script>

import Notification from './components/Notification'
import AppBar from './components/Toolbar'

export default {
  name: 'App',

  components: {
    Notification,
    AppBar
  },

  data: () => ({
    //
  }),
};
</script>
