import { Component } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  constructor(private _userService: UserService) {}
  isLogin = false;
  ngOnInit(): void {
    const helper = new JwtHelperService();
    if (this._userService.Token) {
      this.isLogin = true;
      const decoded = helper.decodeToken(this._userService.Token)
    }
  }
}
