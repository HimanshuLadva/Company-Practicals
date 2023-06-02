import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { AdduserComponent } from './adduser/adduser.component';
import { UpdateuserComponent } from './updateuser/updateuser.component';
import { ViewuserComponent } from './viewuser/viewuser.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AdduserComponent, UpdateuserComponent, ViewuserComponent],
  imports: [CommonModule, UserRoutingModule, ReactiveFormsModule],
})
export class UserModule {}
