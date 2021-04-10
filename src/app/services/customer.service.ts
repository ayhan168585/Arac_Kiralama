import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../Models/customer';
import { ListResponseModel } from '../Models/listResponseModel';
import { ResponseModel } from '../Models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  apiUrl= 'https://localhost:44388/api/'

  constructor(private httpClient:HttpClient) { }

  getCustomers():Observable<ListResponseModel<Customer>>{
    let newPath=this.apiUrl+"customers/getall"
    return this.httpClient.get<ListResponseModel<Customer>>(newPath)
  }

  add(customer:Customer):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"customers/add",customer)
  }

 
}
