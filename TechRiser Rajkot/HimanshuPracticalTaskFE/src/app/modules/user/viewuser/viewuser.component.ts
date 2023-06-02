import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-viewuser',
  templateUrl: './viewuser.component.html',
  styleUrls: ['./viewuser.component.css'],
})
export class ViewuserComponent {
  Users: any[] = [];
  UserList: any[] = [];
  term = '';

  constructor(private _userService: UserService, private _router: Router) {}

  ngOnInit(): void {
    this._userService.getAllUser().subscribe((res) => {
      this.Users = res['data'];
      this.UserList = this.Users;
      console.log(this.Users);
    });
  }

  addUser() {
    this._router.navigate(['user/add']);
  }
  searchWord(data: any) {
    this.term = data;
  }
  deleteUser(Id: any) {
    this.Users = this.Users.filter((x) => x.id != Id);
    this._userService.deleteUser(Id).subscribe();
  }

  editUser(Id: any) {
    this._router.navigate(['user/update', Id]);
  }
}
