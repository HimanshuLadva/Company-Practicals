import { NO_ERRORS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { AdduserComponent } from './adduser/adduser.component';
import { UpdateuserComponent } from './updateuser/updateuser.component';
import { ViewuserComponent } from './viewuser/viewuser.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
  declarations: [AdduserComponent, UpdateuserComponent, ViewuserComponent],
  imports: [CommonModule, UserRoutingModule, FormsModule, ReactiveFormsModule, Ng2SearchPipeModule],
  schemas: [NO_ERRORS_SCHEMA],
})
export class UserModule {}
