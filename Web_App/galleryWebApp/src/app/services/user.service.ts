import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user.model';
import { UserResult } from '../models/user-result.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  httpClient: any;

  constructor(private http: HttpClient) { }

/*   async UserLogin(user: User):Promise<any> {
    return await this.http
      .post<any>(
        'https://webgalleryapi.azure-api.net/v1/api/User/GetAllUsers',
        user,
        {}
      )
      .toPromise();
  }

  login(){
    const httpHeaders = new  HttpHeaders({
      'content-type':'application/json',
      'Authorization': '12345'
    });
    return this.httpClient.get('http://localhost:4200', {headers: httpHeaders})
  } */

  async UserLogin(): Promise<UserResult> {
    const httpHeaders = new  HttpHeaders({
      'content-type':'application/json',
      'Authorization': '12345'
    });
    return await this.httpClient.get('https://webgalleryapi.azure-api.net/v1/api/User/GetAllUsers', {Headers: httpHeaders})
  }
}
