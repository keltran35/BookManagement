using BookManagement.Core.Entities;

namespace BookManagement.Core.Interfaces
{
  public interface IBookRepository
  {
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task<Book> CreateBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
  }
}
