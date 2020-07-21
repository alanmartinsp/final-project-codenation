import Vue from 'vue'
import EventBus from '../plugins/event-bus';

Vue.mixin({
  methods: {
    notify (message, type = 'success') {
      EventBus.$emit('NOTIFICATION_NOTIFY', {
        type: type,
        message: message,
        snackbar: true
      });
    }
  }
})