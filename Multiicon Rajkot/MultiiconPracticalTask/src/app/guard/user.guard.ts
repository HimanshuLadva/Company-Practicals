import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class UserGuard implements CanActivate {
  constructor(
    private _router: Router,
    private _userService: UserService,
    public jwtHelper: JwtHelperService
  ) {}
  canActivate() {
    if (
      this._userService.Token &&
      !this.jwtHelper.isTokenExpired(this._userService.Token)
    ) {
      return true;
    }
    this._router.navigate(['login']);
    return false;
  }
}
