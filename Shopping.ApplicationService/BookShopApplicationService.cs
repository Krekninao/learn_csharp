using System.Collections.Generic;
using System.Linq;
using Shopping.DataAccess;

namespace Shopping.ApplicationService
{
    public class BookShopApplicationService
    {
        public List<IBook> GetBooks()
        {
            using (var dbContext = new ShopContext())
            {
                return dbContext.Books.Select(b => (IBook)b).ToList();
            }
        }

        public Book GetBook(int id)
        {
            using (var dbContext = new ShopContext())
            {
                return dbContext.Books.Single(b => b.ProductIdentificator == id);
            }
        }

        public void AddBook(Book book)
        {
            using (var dbContext = new ShopContext())
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
            using (var dbContext = new ShopContext())
            {
                dbContext.Books.Single(b => b.ProductIdentificator == book.ProductIdentificator).Update(book);
                
            }
        }

        public void DeleteBook(int id)
        {
            using (var dbContext = new ShopContext())
            {
                var delBook = dbContext.Books.Single(b => b.ProductIdentificator == id);
                dbContext.Books.Remove(delBook);
                dbContext.SaveChanges();
            }
        }
    }
}