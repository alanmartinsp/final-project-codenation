<template>
  <div>
    <v-snackbar
      v-model="snackbar"
      :bottom="true"
      :color="color"
      :right="true"
      :timeout="3000"
      :top="false"
      :vertical="mode === 'vertical'">
      {{ message }}
      <v-btn
        dark
        text
        @click="snackbar = false"
        icon
      >
      <v-icon>mdi-close</v-icon>
      </v-btn>
     </v-snackbar>
  </div>
</template>
<script>

import EventBus from '../plugins/event-bus'

export default {

  props: {
  },

  data () {
    return {
      message: '',
      show: false,
      color: '',
      mode: '',
      snackbar: false,
      timeout: 6000,
      x: null,
      y: 'top',
    }
  },

  mounted () {
    var self = this
    EventBus.$on('NOTIFICATION_NOTIFY', (config) => {
      self.color = config.type
      self.message = config.message
      self.snackbar = config.snackbar
    });
  },

  methods: {
  }
}
</script>