using BookManager.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.DAL.Books
{
    public class BooksInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<BooksDbContext>
    {
        protected override void Seed(BooksDbContext context)
        {
            base.Seed(context);

            var books = new List<Book>
            {
                new Book { Title="Book 1", ShortDescription="This book is about something you already know", Price=1.22, IsDeleted=false, CreatedDate=DateTime.Now,
                 Genre=new Genre { Title="Genre 1", CreatedDate=DateTime.Now, IsDeleted=false },
                 Author=new Author { Name = "Author 1", CreatedDate = DateTime.Now, IsDeleted=false }
                },
                new Book { Title="Book 2", ShortDescription="This book is about food", Price=1.22, IsDeleted=false, CreatedDate=DateTime.Now,
                Genre = new Genre { Title="Genre 2", CreatedDate=DateTime.Now, IsDeleted=false },
                Author=new Author { Name = "Author 2", CreatedDate = DateTime.Now, IsDeleted=false }
                },
                new Book { Title="Book 3", ShortDescription="This book is about music", Price=1.22, IsDeleted=false, CreatedDate=DateTime.Now,
                Genre=new Genre { Title="Genre 3", CreatedDate=DateTime.Now, IsDeleted=false },
                Author=new Author { Name = "Author 3", CreatedDate = DateTime.Now, IsDeleted=false }
                },
                new Book { Title="Book 4", ShortDescription="This book is blank", Price=1.22, IsDeleted=false, CreatedDate=DateTime.Now,
                Genre=new Genre { Title="Genre 4", CreatedDate=DateTime.Now, IsDeleted=false },
                Author=new Author { Name = "Author 4", CreatedDate = DateTime.Now, IsDeleted=false }
                }
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}
