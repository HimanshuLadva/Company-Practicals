import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-myacc',
  templateUrl: './myacc.component.html',
  styleUrls: ['./myacc.component.css'],
})
export class MyaccComponent {
  userForm: FormGroup;
  firstName: any;
  lastName: any;
  password: any;
  email: any;
  genderId: any;
  educationId: any;
  id: any;
  educationList: any[] = [];

  disabled = true;
  constructor(private _fb: FormBuilder, private _userService: UserService, private _router: Router) { }

  ngOnInit(): void {
    this._userService.getUserEducation().subscribe((res) => {
      this.educationList = res['data'];
      console.log(this.educationList);
    });

    const helper = new JwtHelperService();
    if (this._userService.Token) {
      const decoded = helper.decodeToken(this._userService.Token)
      this._userService.getUserById(+decoded['UserId']).subscribe((res) => {
        this.id = res['data']['id'];
        this.firstName = res['data']['firstName'];
        this.lastName = res['data']['lastName'];
        this.password = res['data']['password'];
        this.email = res['data']['email'];
        this.genderId = res['data']['genderId'];
        this.educationId = res['data']['genderId'];
      });
    }

    this.userForm = this._fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Password: ['', Validators.required],
      Email: ['', Validators.required],
      GenderId: ['', Validators.required],
      EducationId: ['', Validators.required]
    });
    //  this.userForm.controls['Email'].disable();
  }

  submitData() {
    this._userService.updateUser(this.id, this.userForm.value).subscribe(res => this._router.navigate(['user/view']));

  }

  get userFormControl() {
    return this.userForm.controls;
  }
  get EducationId() {
    return this.userForm.get('EducationId');
  }
  changeEducation(e) {
    console.log(e.value);
    this.educationId.setValue(e.target.value, {
      onlySelf: true,
    });
  }
  moveToList() {
     this._router.navigate(['user/view']);
  }
  logout() {
    this._userService.logout();
  }

  ngOnDestroy(): void {
    location.reload();
  }
}
