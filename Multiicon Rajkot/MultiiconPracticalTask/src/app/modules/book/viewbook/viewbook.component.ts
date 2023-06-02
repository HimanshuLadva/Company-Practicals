import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-viewuserbook',
  templateUrl: './viewbook.component.html',
  styleUrls: ['./viewbook.component.css'],
})
export class ViewbookComponent {
  books: any[] = [];
  constructor(private _bookService: BookService, private _router:Router) {}

  ngOnInit(): void {
    this._bookService.getAllBook().subscribe((res) => {
      this.books = res['data'];
    });
  }
  addBook() {
    this._router.navigate(['book/add']);
  }
  deleteBook(Id: any) {
    this.books = this.books.filter((x) => x.id != Id);
    this._bookService.deleteBook(Id).subscribe();
  }
}
