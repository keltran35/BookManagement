using System.ComponentModel.DataAnnotations;

namespace BookManagement.Core.DTOs
{
  public class BookDTO
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Author is required")]
    public string Author { get; set; }
  }
}
