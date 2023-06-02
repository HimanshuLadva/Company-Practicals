import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LOCURL } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class LocationService {
  constructor(private _http: HttpClient) {}

  addLocation(data: any) {
    return this._http.post(LOCURL + 'AddLocation', data);
  }

  getAllLocation() {
    return this._http.get(LOCURL + 'GetAllLocation');
  }

  deleteLocation(Id: any) {
    return this._http.delete(LOCURL + 'DeleteLocation/' + Id);
  }
}
