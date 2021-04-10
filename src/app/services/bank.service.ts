import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bank } from '../Models/bank';
import { ListResponseModel } from '../Models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class BankService {

  apiUrl="https://localhost:44388/api/"

  constructor(private httpClient:HttpClient) { }

  getBanks():Observable<ListResponseModel<Bank>>{
    let newPath=this.apiUrl+"banks/getall"
    return this.httpClient.get<ListResponseModel<Bank>>(newPath)
  }
}
