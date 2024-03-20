import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Book } from '../../book.model';
import { BookService } from '../../book.service';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent {
  books: Book[];

  constructor(private bookService: BookService) {
    this.books = [];
  }

  ngOnInit(): void {
    this.bookService.getBooks().subscribe({
      next: response => {
        if (response) {
          this.books = response;
        }
      },
      error: error => {
        console.log(error)
      }
    });
  }
}
