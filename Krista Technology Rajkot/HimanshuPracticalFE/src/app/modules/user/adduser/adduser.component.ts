import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css'],
})
export class AdduserComponent {
  userForm: FormGroup;

  constructor(
    private _fb: FormBuilder,
    private _userSerive: UserService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this.userForm = this._fb.group({
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', Validators.required],
      Role: ['', Validators.required],
      IsActive: ['', Validators.required],
    });
  }

  submitData() {
    this._userSerive
      .addUser(this.userForm.value)
      .subscribe((res) => this._router.navigate(['user/view']));
    this.userForm.reset();
  }

  get userFormControl() {
    return this.userForm.controls;
  }

  clearForm() {
    this.userForm.reset();
  }
}
