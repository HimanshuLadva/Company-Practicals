import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ManagementRoutingModule } from './management-routing.module';
import { AdddeptComponent } from './adddept/adddept.component';
import { AddlocationComponent } from './addlocation/addlocation.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AdddeptComponent, AddlocationComponent],
  imports: [CommonModule, ManagementRoutingModule, ReactiveFormsModule],
})
export class ManagementModule {}
