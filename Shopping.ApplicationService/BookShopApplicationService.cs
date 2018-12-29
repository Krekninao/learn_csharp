using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shopping.DataAccess;

namespace Shopping.ApplicationService
{
    public class BookShopApplicationService
    {
        private readonly IServiceProvider _provider;

        public BookShopApplicationService(IServiceProvider provider)
        {
            _provider = provider;
        }
        public List<IBook> GetBooks()
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                return dbContext.Books.Select(b => (IBook)b).ToList();
            }
        }

        public IBook GetBook(int id)
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                return (IBook)dbContext.Books.Select(b => b.ProductIdentificator == id);
            }
        }

        public void AddBook(Book book)
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                dbContext.Books.Add(new Book
                {
                    Price = book.Price,
                    Name = book.Name,
                    Rating = book.Rating,
                    Author = book.Author
                });
                dbContext.SaveChanges();
            }
        }

        public void UpdateBook(IBook book)
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                dbContext.Books.Single(b => b.ProductIdentificator == book.ProductIdentificator).Update(book);
                
            }
        }

        public void DeleteBook(int id)
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                var delBook = dbContext.Books.Single(b => b.ProductIdentificator == id);
                dbContext.Books.Remove(delBook);
            }
        }
    }
}