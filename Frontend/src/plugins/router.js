import Vue from 'vue'
import Router from 'vue-router'

import routeAuth from '@/app/auth/routes.js'
import routeLog from '@/app/log/routes.js'

Vue.use(Router)

var router = new Router({
  mode: 'history',
  routes: [
    // { path: "*", component: Orders, meta: { public: false } },
    ...routeAuth,
    ...routeLog
  ]
})

router.beforeEach((to, from, next) => {

  let user = JSON.parse(localStorage.getItem('user'))
  if (to.fullPath != '/auth' && user == null) {
    next("/auth")
    return
  }
  
  next()
})

export default router
