import { CarImage } from "./carImage";
import { InteriorDetail } from './InteriorDetail';
import { ExteriorDetail } from './exteriorDetail';
import { EngineDetail } from "./EngineDetail";
import { SafetyDetail } from './safetyDetail';

export interface Car {
    Id: string
    Make: string
    Model: string
    Year: Number
    Images?: Array<CarImage>
    InteriorDetail?: InteriorDetail
    ExteriorDetail?: ExteriorDetail
    EngineDetail?: EngineDetail
    SafetyDetail?: SafetyDetail
}