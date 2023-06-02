import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-updateuserbook',
  templateUrl: './updateuser.component.html',
  styleUrls: ['./updateuser.component.css'],
})
export class UpdateuserComponent {
  userForm: FormGroup;
  firstName: any;
  lastName: any;
  password: any;
  email: any;
  genderId: any;
  educationId: any;
  userId:number;
  educationList: any[] = [];


  disabled = true;
  constructor(private _fb: FormBuilder, private _userService: UserService, private _route:ActivatedRoute,private _router:Router) {}

  ngOnInit(): void {
    this._userService.getUserEducation().subscribe((res) => {
      this.educationList = res['data'];
      console.log(this.educationList);
    });

    this._route.paramMap.subscribe(params => {
       this.userId = +params.get('Id');
       this._userService.getUserById(this.userId).subscribe((res) => {
         this.firstName = res['data']['firstName'];
         this.lastName = res['data']['lastName'];
         this.password = res['data']['password'];
         this.email = res['data']['email'];
         this.genderId = res['data']['genderId'];
         this.educationId = res['data']['educationId'];
       });
    })
    
    this.userForm = this._fb.group({
      FirstName: ['',Validators.required],
      LastName: ['',Validators.required],
      Password: ['',Validators.required],
      Email: ['',Validators.required],
      GenderId: ['',Validators.required],
      EducationId: ['',Validators.required],
    });
    // this.userForm.controls['Email'].disable();
  }

  submitData() {
    console.log(this.userForm.value);
    this._userService
      .updateUser(this.userId, this.userForm.value)
      .subscribe((res) => this._router.navigate(['user/view']));
  }
  get EducationId() {
    return this.userForm.get('EducationId');
  }

  get userFormControl() {
    return this.userForm.controls;
 }

 clearForm() {
  this.userForm.reset();
}

  changeEducation(e) {
    console.log(e.value);
    this.EducationId.setValue(e.target.value, {
      onlySelf: true,
    });
  }
}
