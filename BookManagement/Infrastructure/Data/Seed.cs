using System.Text.Json;
using BookManagement.Core.Entities;
using BookManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Data
{
  public class Seed
  {
    public static async Task SeedBooks(ApplicationDbContext context)
    {
      if (await context.Books.AnyAsync()) return;
      var bookData = await File.ReadAllTextAsync("Data/BookSeedData.json");
      var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
      var books = JsonSerializer.Deserialize<List<Book>>(bookData, options);

      foreach (var book in books)
      {
        context.Books.Add(book);
      }

      await context.SaveChangesAsync();
    }
  }
}