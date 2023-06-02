import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-updateuser',
  templateUrl: './updateuser.component.html',
  styleUrls: ['./updateuser.component.css'],
})
export class UpdateuserComponent {
  editUser: FormGroup;
  userId: any;
  educationList: any[] = [];

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _route: ActivatedRoute,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this._userService.getUserEducation().subscribe((res) => {
      this.educationList = res['data'];
      console.log(this.educationList);
    });

    this._route.paramMap.subscribe((params) => {
      this.userId = +params.get('Id');
      this._userService.getUserById(this.userId).subscribe((res) => {});
    });

    this.editUser = this._fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', Validators.required],
      EducationId: ['', Validators.required],
      Website: ['', Validators.required],
      GitLink: ['', Validators.required],
    });
    this._userService.getUserById(this.userId).subscribe((res) => {
      console.log(res['data']);
      this.editUser.get('FirstName').setValue(res['data']['firstName']);
      this.editUser.get('LastName').setValue(res['data']['lastName']);
      this.editUser.get('Email').setValue(res['data']['email']);
      this.editUser.get('Password').setValue(res['data']['password']);
      const index = this.educationList.findIndex(ele => ele.educationName == res['data']['education']);
      this.editUser.get('EducationId').setValue(this.educationList[index].id);
      this.editUser.get('Website').setValue(res['data']['website']);
      this.editUser.get('GitLink').setValue(res['data']['gitLink']);
    });
    // this.editUser.controls['Email'].disable();
  }

  submitData() {
    console.log(this.editUser.value);
    this._userService
      .updateUser(this.userId, this.editUser.value)
      .subscribe((res) => this._router.navigate(['user/view']));
  }
  get EducationId() {
    return this.editUser.get('EducationId');
  }

  get editUserControl() {
    return this.editUser.controls;
  }

  clearForm() {
    this.editUser.reset();
  }
}
