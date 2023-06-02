import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from '../models/auth.model';
import { USERURL } from 'src/environments/environment.development';
import { LocalstorageService } from './localstorage.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  token = 'Token';

  constructor(
    private _http: HttpClient,
    private _localStorageService: LocalstorageService,
    private _router: Router
  ) {}

  checkLogin(model: LoginModel): Observable<any> {
    return this._http.post(USERURL + 'checkLogin', model);
  }

  addUser(data: any) {
    return this._http.post(USERURL + 'AddUser', data);
  }

  updateUser(Id: any, data: any) {
    return this._http.put(USERURL + 'UpdateUser/' + Id, data);
  }

  deleteUser(Id: any) {
    return this._http.delete(USERURL + 'DeleteUser/' + Id);
  }

  getAllUser() {
    return this._http.get(USERURL + 'GetAllUser');
  }
  getUserById(Id: any) {
    return this._http.get(USERURL + 'GetUserById/' + Id);
  }
  getCurrentLoggedInUser(Id:any) {
    return this._http.get(USERURL + 'GetCurrentLoggedInUser');
  }

  getUserEducation() {
    return this._http.get(USERURL + 'GetUserEducation');
  }

  logout() {
    if (this.Token) {
      this._localStorageService.removeItem(this.token);
      this._router.navigate(['login']);
    }
  }
  get Token() {
    return this._localStorageService.getItem(this.token);
  }

  tokenExpired(token: any) {
    const expiry = JSON.parse(atob(token.split('.')[1])).exp;
    return Math.floor(new Date().getTime() / 1000) >= expiry;
  }
}
