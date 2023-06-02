import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DEPTURL } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  constructor(private _http: HttpClient) {}

  addDepartment(data: any) {
    return this._http.post(DEPTURL + 'AddDepartment', data);
  }

  getAllDepartment() {
    return this._http.get(DEPTURL + 'GetAllDepartment');
  }

  deleteDepartment(Id: any) {
    return this._http.delete(DEPTURL + 'DeleteDepartment/' + Id);
  }

  getDepartmentWiseLocation(Id:any) {
    return this._http.get(DEPTURL + 'GetDepartmentWiseLocation/' + Id);
  }
}
