using BookManagement.Core.DTOs;

namespace BookManagement.Core.Interfaces
{
  public interface IBookService
  {
    Task<IEnumerable<BookDTO>> GetBooksAsync();
    Task<BookDTO> GetBookByIdAsync(int id);
    Task<BookDTO> CreateBookAsync(BookDTO bookDTO);
    Task UpdateBookAsync(int id, BookDTO bookDTO);
    Task DeleteBookAsync(int id);
  }
}