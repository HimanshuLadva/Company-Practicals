import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalstorageService {
  
  constructor() { }

  setItem(name:string, data:any) {
     localStorage.setItem(name, JSON.stringify(data));
  }

  getItem(name:string) {
     return JSON.parse(localStorage.getItem(name)) || null;
  }

  removeItem(name:string) {
     localStorage.removeItem(name);
  }
}
