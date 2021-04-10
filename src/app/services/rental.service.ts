import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../Models/listResponseModel';
import { Rental } from '../Models/Rental';
import { RentalDetail } from '../Models/rentalDetail';
import { ResponseModel } from '../Models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiUrl= 'https://localhost:44388/api/'

  constructor(private httpclient:HttpClient) { }

  GetRentalDetail():Observable<ListResponseModel<RentalDetail>>{
    let newPath=this.apiUrl+"rentals/getrentaldetail"
    return this.httpclient.get<ListResponseModel<RentalDetail>>(newPath)
  }
  getRentals():Observable<ListResponseModel<Rental>>{
    let newPath=this.apiUrl+"rentals/getall"
    return this.httpclient.get<ListResponseModel<Rental>>(newPath)
  }
  add(rental:Rental):Observable<ResponseModel>{
   
    return this.httpclient.post<ResponseModel>(this.apiUrl+"rentals/add",rental)
  }

  getrentalsbycarid(carId:number):Observable<ListResponseModel<RentalDetail>>{
    let newPath=this.apiUrl+"rentals/getrentalsbycarid?="+carId
    return this.httpclient.get<ListResponseModel<RentalDetail>>(newPath)
  }
}
