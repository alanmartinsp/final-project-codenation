import List from '@/app/log/List'
import Form from '@/app/log/Form'

export default [
  {
    path: '/log',
    meta: {
      public: false
    },
    name: 'Log',
    component: List
  },
  {
    path: '/log/:id',
    meta: {
      public: false
    },
    name: 'Log Item',
    component: Form
  },
  {
    path: "/",
    redirect: "/log"
  }
]