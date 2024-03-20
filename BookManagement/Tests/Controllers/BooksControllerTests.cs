using System.Collections.Generic;
using System.Threading.Tasks;
using BookManagement.Core.DTOs;
using BookManagement.Core.Entities;
using BookManagement.Core.Interfaces;
using BookManagement.Core.Services;
using BookManagement.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BookManagement.Tests.Controllers
{
  public class BooksControllerTests
  {
    [Fact]
    public async Task GetBooks_ReturnsOkResult()
    {
      // Arrange
      var mockRepository = new Mock<IBookRepository>();
      var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2" }
            };
      mockRepository.Setup(repo => repo.GetBooksAsync()).ReturnsAsync(books);
      var service = new BookService(mockRepository.Object);

      // Act
      var result = await service.GetBooksAsync();

      // Assert
      Assert.NotNull(result);
    }

    [Fact]
    public async Task GetBookByIdAsync_ReturnsBookDTO()
    {
      // Arrange
      var mockRepository = new Mock<IBookRepository>();
      var book = new Book { Id = 1, Title = "Book 1", Author = "Author 1" };
      mockRepository.Setup(repo => repo.GetBookByIdAsync(1)).ReturnsAsync(book);
      var service = new BookService(mockRepository.Object);

      // Act
      var result = await service.GetBookByIdAsync(1);

      // Assert
      Assert.NotNull(result);
      Assert.Equal("Book 1", result.Title);
      Assert.Equal("Author 1", result.Author);
    }

    [Fact]
    public async Task CreateBookAsync_ReturnsCreatedBookDTO()
    {
      // Arrange
      var mockRepository = new Mock<IBookRepository>();
      var bookDTO = new BookDTO { Title = "New Book", Author = "New Author" };
      var createdBook = new Book { Id = 1, Title = "New Book", Author = "New Author" };
      mockRepository.Setup(repo => repo.CreateBookAsync(It.IsAny<Book>())).ReturnsAsync(createdBook);
      var service = new BookService(mockRepository.Object);

      // Act
      var result = await service.CreateBookAsync(bookDTO);

      // Assert
      Assert.NotNull(result);
      Assert.Equal(1, result.Id); // Assuming the ID returned by repository is 1
      Assert.Equal("New Book", result.Title);
      Assert.Equal("New Author", result.Author);
    }

    [Fact]
    public async Task UpdateBookAsync_ThrowsException_WhenBookNotFound()
    {
      // Arrange
      var mockRepository = new Mock<IBookRepository>();
      mockRepository.Setup(repo => repo.GetBookByIdAsync(1)).ReturnsAsync((Book)null);
      var service = new BookService(mockRepository.Object);

      // Act and Assert
      await Assert.ThrowsAsync<Exception>(async () =>
      {
        await service.UpdateBookAsync(1, new BookDTO { Title = "Updated Book", Author = "Updated Author" });
      });
    }

  }
}
