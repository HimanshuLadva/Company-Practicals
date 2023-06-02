import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartmentService } from 'src/app/services/department.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css'],
})
export class EdituserComponent {
  userForm: FormGroup;
  userId: number;
  departmentwiseLocation: any[] = [];
  checkObj: {
    Departments: any[];
    Locations: any[];
  } = { Departments: [], Locations: [] };

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _deptService: DepartmentService,
    private _router: Router,
    private _route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this._route.paramMap.subscribe((res) => {
      this.userId = +res.get('id');
    });
    this._deptService
      .getDepartmentWiseLocation(this.userId)
      .subscribe((res) => {
        this.departmentwiseLocation = res['data'];
        console.log('GetDepartmentWiseLocation', this.departmentwiseLocation);
        this.departmentwiseLocation.forEach((ele, index) => {
          if (ele.isSelected) {
            this.checkObj.Departments.push(ele.id);
            this.departmentwiseLocation[index].locationNames.map(
              (ele1: any) => (ele1.isSelected = ele.isSelected)
            );
          }
          this.departmentwiseLocation[index].locationNames.forEach(
            (ele1: any) => {
              if (
                ele1.isSelected &&
                this.checkObj.Departments.findIndex((ele2) => ele2 == ele.id) ==
                -1
              ) {
                this.checkObj.Locations.push({
                  Id: ele1.id,
                  DeptID: ele.id,
                });
              }
            }
          );
        });
        console.log(this.checkObj);
      });

    this.userForm = this._fb.group({
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', Validators.required],
      Role: ['', Validators.required],
      IsActive: ['', Validators.required],
    });

   

    this._userService.getUserById(this.userId).subscribe((res) => {
      this.userForm.get('Name').setValue(res['data']['name']);
      this.userForm.get('Email').setValue(res['data']['email']);
      this.userForm.get('Password').setValue(res['data']['password']);
      this.userForm.get('Role').setValue(res['data']['role']);
      this.userForm.get('IsActive').setValue(res['data']['isActive']);
    });
  }

  submitData() {
    this._userService
      .updateUser(this.userId, this.userForm.value)
      .subscribe((res) => this._router.navigate(['user/view']));
    this.userForm.reset();
  }

  get userFormControl() {
    return this.userForm.controls;
  }

  clearForm() {
    this.userForm.reset();
  }

  checkBoxForLocation(locationID: any, DeptID: any) {
      const deptIndex = this.departmentwiseLocation.findIndex(ele => ele.id == DeptID);
      const locIndex = this.departmentwiseLocation[deptIndex].locationNames.findIndex(loc => loc.id == locationID);

      if(this.departmentwiseLocation[deptIndex].isSelected){
         this.departmentwiseLocation[deptIndex].locationNames[locIndex].isSelected=false;
         this.departmentwiseLocation[deptIndex].isSelected = false;
         console.log("Selected Current Obj",this.departmentwiseLocation[deptIndex]);
         this.checkObj.Departments = this.checkObj.Departments.filter(ele => ele.id != DeptID);
         this.departmentwiseLocation[deptIndex].locationNames.forEach(ele => {
             if(ele.id != locationID) {
                this.checkObj.Locations.push({
                   Id:ele.id,
                   DeptID:DeptID
                })
             }
         });
      }
      else {
        console.log("this is else");
         if(this.checkObj.Locations.findIndex(ele => ele.Id == locationID) != -1) {
            console.log("this is already");
            this.checkObj.Locations = this.checkObj.Locations.filter(ele => ele.Id != locationID);
            this.departmentwiseLocation[deptIndex].locationNames[locIndex].isSelected = false;
            console.log("Current Obj",this.departmentwiseLocation[deptIndex]);
            console.log("Current Obj",this.checkObj.Locations);
         }
         else {
           this.checkObj.Locations.push({
             Id: locationID,
             DeptID: DeptID
           });
           this.departmentwiseLocation[deptIndex].locationNames[locIndex].isSelected = true;
           const locArr = this.checkObj.Locations.filter(ele => ele.DeptID == DeptID);
           if(locArr.length == this.departmentwiseLocation[deptIndex].locationNames.length) {
               this.checkObj.Departments.push(DeptID);
               this.checkObj.Locations =this.checkObj.Locations.filter(ele => ele.DeptID != DeptID);
               this.departmentwiseLocation[deptIndex].isSelected = true;
           }
         }
      }
  }

  checkBoxForDepartment(DeptID: any) {
    this.departmentwiseLocation.map((ele) => {
      if (ele.id == DeptID) {
        ele.isSelected = !ele.isSelected;
        console.log(ele.isSelected);
        ele.locationNames.map(
          (ele1: any) => (ele1.isSelected = ele.isSelected)
        );
      }
    });
    console.log(this.departmentwiseLocation);
    if (this.checkObj.Departments.findIndex((ele) => ele == DeptID) != -1) {
      this.checkObj.Departments = this.checkObj.Departments.filter(
        (ele) => ele != DeptID
      );
    } else {
      this.checkObj.Departments.push(DeptID);
      this.checkObj.Locations = this.checkObj.Locations.filter(
        (ele) => ele.DeptID != DeptID
      );
    }
  }

  submitCheckedData() {
    console.log(this.userId);
    console.log(this.checkObj); 
    this._userService
      .assignDeptORLocationToUser(this.userId, this.checkObj)
      .subscribe();
  }
}
