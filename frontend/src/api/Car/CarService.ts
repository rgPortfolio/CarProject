import { API_BASE, CAR_BASE } from "../ApiConstants"
import { get } from "../RequestService"

export const getCars = () => {
    const url = new URL(`${API_BASE}${CAR_BASE}/`)
    return get(url.toString())
}

export const getCar = (id: string) => {
    const url = new URL(`${API_BASE}${CAR_BASE}/${id}`)
    return get(url.toString())
}