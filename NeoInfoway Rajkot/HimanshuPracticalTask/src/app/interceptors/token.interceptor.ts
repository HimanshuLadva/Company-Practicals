import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalstorageService } from '../services/localstorage.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private _localStorageService: LocalstorageService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
     request = request.clone({
       setHeaders: {
         Authorization: `Bearer ${this._localStorageService.getItem("Token")}`,
       },
     });
    return next.handle(request);
  }
}
