import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-viewuserbook',
  templateUrl: './viewuser.component.html',
  styleUrls: ['./viewuser.component.css'],
})
export class ViewuserComponent {
  Users: any[] = [];

  constructor(private _userService: UserService, private _router:Router) {}

  ngOnInit(): void {
    this._userService.getAllUser().subscribe((res) => {
      this.Users = res['data'];
    });
  }

  addUser() {
    this._router.navigate(['user/add']);
  }

  deleteUser(Id: any) {
    this.Users = this.Users.filter((x) => x.id != Id);
    this._userService.deleteUser(Id).subscribe();
  }
}
