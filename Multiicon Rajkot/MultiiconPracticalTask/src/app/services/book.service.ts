import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BOOKURL } from 'src/environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  constructor(private _http: HttpClient) {}

  addBook(data: any): Observable<any> {
    return this._http.post(BOOKURL + 'addBook', data);
  }

  getAllBook(): Observable<any> {
    return this._http.get(BOOKURL + 'GetAllBook');
  }

  deleteBook(Id: any): Observable<any> {
    return this._http.delete(BOOKURL + 'DeleteBook/' + Id);
  }
}
