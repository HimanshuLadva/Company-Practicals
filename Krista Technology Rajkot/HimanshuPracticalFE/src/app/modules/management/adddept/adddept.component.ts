import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from 'src/app/services/department.service';

@Component({
  selector: 'app-adddept',
  templateUrl: './adddept.component.html',
  styleUrls: ['./adddept.component.css'],
})
export class AdddeptComponent {
  deptForm: FormGroup;
  departments:any[]=[];

  constructor(private _fb: FormBuilder, private _deptService:DepartmentService) {}

  ngOnInit(): void {
    this._deptService.getAllDepartment().subscribe(res => {
       this.departments = res['data'];
       console.log(this.departments);
    })
    this.deptForm = this._fb.group({
      Name: ['', Validators.required]
    });
  }

  submitData() {
    console.log(this.deptForm.value['Name']);
    this._deptService.addDepartment(this.deptForm.value).subscribe(res => {
        this.departments.push(res['data']);
    });
    this.deptForm.reset();
  }

  get deptFormControl() {
    return this.deptForm.controls;
  }

  deleteDepartment(Id:any) {
     this._deptService.deleteDepartment(Id).subscribe();   
  }

  clearForm() {
    this.deptForm.reset();
  }
}
