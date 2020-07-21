import Form from '@/app/auth/Form'

export default [
  {
    path: '/auth',
    meta: {
      public: true
    },
    name: 'Login',
    component: Form
  }
]