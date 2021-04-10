import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../Models/listResponseModel';
import { ResponseModel } from '../Models/responseModel';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl= 'https://localhost:44388/api/'

  constructor(private httpClient:HttpClient) { }

  getUsers():Observable<ListResponseModel<User>>{
    let newPath=this.apiUrl+"users/getall"
    return this.httpClient.get<ListResponseModel<User>>(newPath)
  }
  add(user:User):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"users/add",user)
  }
}
