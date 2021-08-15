import axios from "axios"
import { API_BASE } from "./ApiConstants"

// configured instance of Axios
export const CarProjectApi = axios.create({
    baseURL: API_BASE
  })
  CarProjectApi.interceptors.response.use(
    function (response) {
      return response
    },
    function (error) {
      console.error(error)
      return Promise.reject(error)
    }
  )
