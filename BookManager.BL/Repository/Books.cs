using BookManager.BL.Interfaces;
using BookManager.DAL.Books;
using BookManager.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BL.Repository
{
    public class Books: RepositoryBase<Book>
    {
        public Books():base(new BooksDbContext())
        {

        }
    }
}
