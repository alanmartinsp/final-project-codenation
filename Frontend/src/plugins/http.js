import axios from 'axios'
import router from './router'

const http = axios.create({
  baseURL: "http://localhost:51325/api/",
  headers: {
    Authorization: {
      toString () {
        return `Bearer ${localStorage.getItem('token')}`
      }
    },
    'Content-Type': 'application/json'
  }
})

http.interceptors.response.use(response => {
  return response
}, function (error) {
  let httpStatus = error.response.status
  switch (httpStatus) {
    case 401: {
      localStorage.clear()
      router.push('/auth')
      break
    }

    case 500: {
      window.Vue.notify(error.response.data.message, 'error')
      break
    }
  }

  return Promise.reject(error)
})

export default http
