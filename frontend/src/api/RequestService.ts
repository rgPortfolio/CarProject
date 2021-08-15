import { AxiosResponse } from "axios"
import { CarProjectApi } from './AxiosInstance';

//implemented this in an enterprise project to standardize how calls from the frontend were made

export async function get<T>(url: string) {
  return await CarProjectApi.get(url)
    .then((response: AxiosResponse<T>) => response.data)
    .catch((error) => {
      console.error(error)
    })
}

export async function post<T>(url: string, data: any, getData = false) {
  return await CarProjectApi.post(url, data)
    .then((response: AxiosResponse<T>) => {
      if (response.status === 201 && getData) {
        return response.data
      } else if (response.status === 201 && response.headers.location) {
        const createdAt = new URL(response.headers.location)
        return createdAt.search ? createdAt.search : createdAt.pathname.split("/").pop()
      }
    })
    .catch((error) => {
      console.error(error)
    })
}

export async function patch<T>(url: string, data: any) {
  return await CarProjectApi.patch(url, data)
    .then((response: AxiosResponse<T>) => {
      if (response.status === 204) return data
    })
    .catch((error) => {
      console.error(error)
      return { statusCode: error.response.status, message: error.message }
    })
}

export async function put<T>(url: string, data: any) {
  return await CarProjectApi.put(url, data)
    .then((response: AxiosResponse<T>) => {
      if (response.status === 204 || response.status === 202) return data
    })
    .catch((error) => {
      console.error(error)
      return { statusCode: error.response.status, message: error.message }
    })
}
