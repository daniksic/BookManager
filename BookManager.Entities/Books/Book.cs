using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Entities.Books
{
    public class Book: EntityBase
    {
        //	• Author, Title, Genre, Price, PublicationDate, Short Description (200 characters)
        [MaxLength(40)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
