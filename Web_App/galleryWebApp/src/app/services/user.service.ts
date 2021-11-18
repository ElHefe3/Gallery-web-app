import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { UserResult } from '../models/user-result.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  async UserLogin(user: User):Promise<any> {
    return await this.http
      .post<any>(
        '',
        user,
        {}
      )
      .toPromise();
  }
}
