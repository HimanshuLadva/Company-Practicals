import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookRoutingModule } from './book-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddbookComponent } from './addbook/addbook.component';
import { ViewbookComponent } from './viewbook/viewbook.component';
import { UpdatebookComponent } from './updatebook/updatebook.component';



@NgModule({
  declarations: [AddbookComponent, ViewbookComponent, UpdatebookComponent],
  imports: [CommonModule, BookRoutingModule, ReactiveFormsModule],
})
export class BookModule {}
