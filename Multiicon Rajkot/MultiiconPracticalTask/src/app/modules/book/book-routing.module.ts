import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddbookComponent } from './addbook/addbook.component';
import { ViewbookComponent } from './viewbook/viewbook.component';
import { UpdatebookComponent } from './updatebook/updatebook.component';

const routes: Routes = [
   {
     path:"add",
     component:AddbookComponent,
   },
   {
     path:"view",
     component:ViewbookComponent,
   },
   {
     path:"update",
     component:UpdatebookComponent
   }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookRoutingModule { }
