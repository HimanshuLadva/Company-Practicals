import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LocalstorageService } from 'src/app/services/localstorage.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  userLogin: FormGroup;
  token = 'Token';

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _router: Router,
    private _localStorageService: LocalstorageService
  ) {}

  ngOnInit(): void {
    this.userLogin = this._fb.group({
      Email: [''],
      Password: [''],
    });
  }

  submitData() {
    this._userService.checkLogin(this.userLogin.value).subscribe((res) => {
      if (res['success'] == true) {
        this._router.navigate(['']);
        this._localStorageService.setItem(this.token, res['data']['token']);
      }
    });
  }

  ngOnDestroy() {
    location.reload();
  }
}
