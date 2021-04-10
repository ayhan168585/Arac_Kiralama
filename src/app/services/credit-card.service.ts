import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreditCard } from '../Models/creditCard';
import { ListResponseModel } from '../Models/listResponseModel';
import { ResponseModel } from '../Models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class CreditCardService {

 apiUrl= 'https://localhost:44388/api/'

  constructor(private httpClient:HttpClient) { }

  getCreditcards():Observable<ListResponseModel<CreditCard>>{
    let newPath=this.apiUrl+"creditCards/getall"
    return this.httpClient.get<ListResponseModel<CreditCard>>(newPath)
  }

  add(creditCard:CreditCard):Observable<ResponseModel>{

    return this.httpClient.post<ResponseModel>(this.apiUrl+"creditCards/add",creditCard)
  }
}
