import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { USERURL } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  token = 'Token';

  constructor(
    private _http: HttpClient,
  ) {}

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
  
  getUserEducation() {
    return this._http.get(USERURL + 'GetUserEducation');
  }
}
