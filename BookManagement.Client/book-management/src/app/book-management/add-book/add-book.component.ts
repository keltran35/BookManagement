import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BookService } from '../book.service';
import { Book } from '../book.model';
import { NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent {
  bookForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private bookService: BookService, private toastr: ToastrService) {
    this.bookForm = this.formBuilder.group({
      title: ['', Validators.required],
      author: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.bookForm.invalid) {
      return;
    }
    const newBook: Book = this.bookForm.value;
    this.bookService.addBook(newBook).subscribe({
      next: _ => {
        this.clearForm();
        this.toastr.success('Add book succesfully');
      }
    });
  }

  clearForm(): void {
    this.bookForm.reset();
  }

  get formControls() {
    return this.bookForm.controls;
  }
}
