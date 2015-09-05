using System.ComponentModel.DataAnnotations;

namespace BookManager.Entities.Books
{
    public class Genre:EntityBase
    {
        [MaxLength(40)]
        public string Title { get; set; }
    }
}