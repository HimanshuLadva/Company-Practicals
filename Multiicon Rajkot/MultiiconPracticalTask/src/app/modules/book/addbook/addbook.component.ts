import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-adduserbook',
  templateUrl: './addbook.component.html',
  styleUrls: ['./addbook.component.css'],
})
export class AddbookComponent {
  book: FormGroup;

  constructor(private _fb: FormBuilder, private _bookService:BookService) {}

  ngOnInit(): void {
    this.book = this._fb.group({
      Title: [''],
      Author: [''],
      Description: ['']
    });
  }

  submitData() {
    this._bookService.addBook(this.book.value).subscribe();
    this.book.reset();
  }
}
