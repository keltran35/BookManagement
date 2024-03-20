using BookManagement.Core.DTOs;
using BookManagement.Core.Entities;
using BookManagement.Core.Interfaces;

namespace BookManagement.Core.Services
{
  public class BookService : IBookService
  {
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    }

    public async Task<IEnumerable<BookDTO>> GetBooksAsync()
    {
      var books = await _bookRepository.GetBooksAsync();
      var bookDTOs = new List<BookDTO>();
      foreach (var book in books)
      {
        bookDTOs.Add(new BookDTO
        {
          Id = book.Id,
          Title = book.Title,
          Author = book.Author,
        });
      }
      return bookDTOs;
    }

    public async Task<BookDTO> GetBookByIdAsync(int id)
    {
      var book = await _bookRepository.GetBookByIdAsync(id);
      if (book == null)
        return null;

      return new BookDTO
      {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
      };
    }

    public async Task<BookDTO> CreateBookAsync(BookDTO bookDTO)
    {
      var book = new Book
      {
        Title = bookDTO.Title,
        Author = bookDTO.Author,
      };

      var createdBook = await _bookRepository.CreateBookAsync(book);

      return new BookDTO
      {
        Id = createdBook.Id,
        Title = createdBook.Title,
        Author = createdBook.Author,
      };
    }

    public async Task UpdateBookAsync(int id, BookDTO bookDTO)
    {
      var existingBook = await _bookRepository.GetBookByIdAsync(id);
      if (existingBook == null)
      {
        throw new Exception($"Book with id {id} not found");
      }

      existingBook.Title = bookDTO.Title;
      existingBook.Author = bookDTO.Author;

      await _bookRepository.UpdateBookAsync(existingBook);
    }

    public async Task DeleteBookAsync(int id)
    {
      var existingBook = await _bookRepository.GetBookByIdAsync(id);
      if (existingBook == null)
      {
        throw new Exception($"Book with id {id} not found");
      }

      await _bookRepository.DeleteBookAsync(id);
    }
  }
}
