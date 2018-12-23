using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FileInput = System.IO.File;

namespace Shopping.Frontend.Controllers
{
    [Route("api/[controller]")]
    public class BookShopController: Controller
    {
        private readonly BookShop _bookShop;
        public BookShopController(IServiceProvider serviceProvider)
        {
            using (var dbContext =
                new ShopContext(serviceProvider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                var items = _bookShop.GetItems();
                foreach (var item in items)
                {
                    dbContext.Books.Add(new Book
                    {
                        Price = item.Price,
                        Name = item.Name,
                        Rating = item.Rating,
                        Author = item.Author
                    });
                }

                dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public List<IBook> GetBooks()
        {
            return _bookShop.GetItems();
        }

        [HttpGet("{id}")]
        public IBook GetBook(int id)
        {
            return _bookShop.GetItem(id);
        }

        [HttpPost]
        public List<IBook> AddBook([FromBody] Book book)
        {

            _bookShop.AddItem(book);
            return _bookShop.GetItems();
        }

        [HttpPut]
        public List<IBook> UpdateBook([FromBody] Book newBook)
        {
            _bookShop.UpdateItem(newBook);
            return _bookShop.GetItems();
        }

        [HttpDelete("{id}")]
        public List<IBook> DeleteBook(int id)
        {
            _bookShop.Remove(id);
            return _bookShop.GetItems();
        }
    }
}
