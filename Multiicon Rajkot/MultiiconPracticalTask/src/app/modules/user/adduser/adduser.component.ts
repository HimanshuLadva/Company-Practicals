import { Component } from '@angular/core';
import { FormBuilder , FormGroup} from "@angular/forms";
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-adduserbook',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css'],
})
export class AdduserComponent {
  user:FormGroup;
   
  constructor(private _fb:FormBuilder, private _userService:UserService) {}

  ngOnInit():void {
      this.user = this._fb.group({
        FirstName: [''],
        LastName: [''],
        Email: [''],
        Password: [''],
        IsAdmin: [''],
      });
  }

  submitData() {
     this._userService.addUser(this.user.value).subscribe();
     this.user.reset();
  }
}
