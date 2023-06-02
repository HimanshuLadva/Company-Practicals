import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-adduserbook',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css'],
})
export class AdduserComponent {
  user: FormGroup;
  educationList: any[] = [];

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this._userService.getUserEducation().subscribe((res) => {
      this.educationList = res['data'];
      console.log(this.educationList);
    });
    this.user = this._fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', Validators.required],
      EducationId: ['', Validators.required],
      Website: ['', Validators.required],
      GitLink: ['', Validators.required],
    });
  }

  submitData() {
    console.log(this.user.value);
    this.user.value.EducationId = +this.user.value.EducationId;
    this._userService
      .addUser(this.user.value)
      .subscribe((res) => this._router.navigate(['user/view']));
    this.user.reset();
  }


  get userFormControl() {
    return this.user.controls;
  }

  clearForm() {
    this.user.reset();
  }
}
