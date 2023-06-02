import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-myacc',
  templateUrl: './myacc.component.html',
  styleUrls: ['./myacc.component.css'],
})
export class MyaccComponent {
  userForm: FormGroup;
  firstName:any;
  lastName:any;
  password:any;
  email:any;
  disabled = true;
  constructor(private _fb: FormBuilder, private _userService: UserService) {}

  ngOnInit(): void {
    this._userService.getUserById().subscribe((res) => {
      this.firstName = res['data']['firstName'];
      this.lastName = res['data']['lastName'];
      this.password = res['data']['password'];
      this.email  = res['data']['email'];
    });
     this.userForm = this._fb.group({
       FirstName: [''],
       LastName: [''],
       Password: [''],
       Email:['']
     });
     this.userForm.controls['Email'].disable();
  }

  submitData() {
    this._userService.updateUser(this.userForm.value).subscribe();
  }

  logout() {
    this._userService.logout();
  }

  ngOnDestroy(): void {
    location.reload();
  }
}
