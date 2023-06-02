import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from 'src/app/services/department.service';
import { LocationService } from 'src/app/services/location.service';

@Component({
  selector: 'app-addlocation',
  templateUrl: './addlocation.component.html',
  styleUrls: ['./addlocation.component.css'],
})
export class AddlocationComponent {
  locationForm: FormGroup;
  locations: any[] = [];
  departments: any[] = [];

  constructor(
    private _fb: FormBuilder,
    private _locationService:LocationService,
    private _deptService:DepartmentService
  ) {}

  ngOnInit(): void {
    this._deptService.getAllDepartment().subscribe((res) => {
      this.departments = res['data'];
      console.log("departments", this.departments);
    });
    this._locationService.getAllLocation().subscribe((res) => {
      this.locations = res['data'];
      console.log("locaitons",this.locations);
    });
    this.locationForm = this._fb.group({
      Name: ['', Validators.required],
      DepartmentId:['', Validators.required]
    });
  }

  submitData() {
    console.log(this.locationForm.value['Name']);
    this._locationService.addLocation(this.locationForm.value).subscribe((res) => {
      this.locations.push(res['data']);
    });
    this.locationForm.reset();
  }

  get locationFormControl() {
    return this.locationForm.controls;
  }

  deleteDepartment(Id: any) {
    this._locationService.deleteLocation(Id).subscribe();
  }

  clearForm() {
    this.locationForm.reset();
  }
}
