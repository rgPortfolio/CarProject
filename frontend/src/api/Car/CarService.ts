import { Car } from "../../Models/car";
import { API_BASE, CAR_BASE } from "../ApiConstants";
import { get } from "../RequestService";

export const getCars = async (): Promise<Array<Car>> => {
  const url = new URL(`${API_BASE}${CAR_BASE}/`);
  const response = (await get(url.toString())) as Array<Car>;
  if (response && response?.length > 0) {
    return response;
  } else {
    return [] as Array<Car>;
  }
};

export const getCar = async (id: string): Promise<Car>=> {
  const url = new URL(`${API_BASE}${CAR_BASE}/${id}`);
  const response = (await get(url.toString())) as Car;
  if (response && response?.Id) {
    return response;
  } else {
    return {} as Car;
  }
};
