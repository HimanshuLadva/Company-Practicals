import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdduserComponent } from './adduser/adduser.component';
import { ViewuserComponent } from './viewuser/viewuser.component';
import { EdituserComponent } from './edituser/edituser.component';

const routes: Routes = [
   {
     path:"add",
     component:AdduserComponent
   },
   {
     path:"view",
     component:ViewuserComponent
   },
   {
     path:"edit/:id",
     component:EdituserComponent
   }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
