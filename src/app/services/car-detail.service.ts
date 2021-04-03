import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarDetail } from '../Models/carDetail';
import { ListResponseModel } from '../Models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CarDetailService {

  apiUrl="https://localhost:44388/api/"
  constructor(private httpClient:HttpClient) { }

 

  getcarsByBrand(brandId:number):Observable<ListResponseModel<CarDetail>>{
let newPath=this.apiUrl+"cars/getcarsbybrand?brandid="+brandId
return this.httpClient.get<ListResponseModel<CarDetail>>(newPath)
  }

  getcarsByColorId(colorId:number):Observable<ListResponseModel<CarDetail>>{
    let newPath=this.apiUrl+"cars/getcarsbycolorid?colorid="+colorId
    return this.httpClient.get<ListResponseModel<CarDetail>>(newPath)
  }

  getCarById(carId:number):Observable<ListResponseModel<CarDetail>>{
    let newPath= this.apiUrl+"cars/getcarbyid?carid="+carId
    return this.httpClient.get<ListResponseModel<CarDetail>>(newPath)
  }

  getCarDetail():Observable<ListResponseModel<CarDetail>>{
    let newPath=this.apiUrl+"cars/getcardetail"
    return this.httpClient.get<ListResponseModel<CarDetail>>(newPath)
  }
}
