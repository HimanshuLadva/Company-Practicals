import { NgModule, ViewChild } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdduserComponent } from './adduser/adduser.component';
import { ViewuserComponent } from './viewuser/viewuser.component';
import { UpdateuserComponent } from './updateuser/updateuser.component';

const routes: Routes = [
   {
     path:"add",
     component:AdduserComponent,
   },
   {
     path:"view",
     component:ViewuserComponent,
   },
   {
     path:"update/:Id",
     component:UpdateuserComponent
   }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
