using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookManager.Entities.Books;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookManager.DAL.Books
{
    [DbConfigurationType(typeof(DefaultDbConfig))]
    public class BooksDbContext : DbContext
    {
        public BooksDbContext():base("BooksContext")
        {
        }
        public BooksDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
