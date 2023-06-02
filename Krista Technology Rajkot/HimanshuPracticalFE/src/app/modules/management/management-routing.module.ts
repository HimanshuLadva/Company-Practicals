import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdddeptComponent } from './adddept/adddept.component';
import { AddlocationComponent } from './addlocation/addlocation.component';

const routes: Routes = [
   {
     path:"adddept",
     component:AdddeptComponent
   },
   {
     path:"addlocation",
     component:AddlocationComponent
   }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagementRoutingModule { }
