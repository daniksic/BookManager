using System.ComponentModel.DataAnnotations;

namespace BookManager.Entities.Books
{
    public class Author:EntityBase
    {
        [MaxLength(40)]
        public string Name { get; set; }
    }
}