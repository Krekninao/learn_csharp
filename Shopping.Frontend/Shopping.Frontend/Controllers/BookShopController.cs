using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FileInput = System.IO.File;

namespace Shopping.Frontend.Controllers
{
    [Route("api/[controller]")]
    public class BookShopController: Controller
    {
        private BookShop _bookShop;
        public BookShopController()
        {
            var bookDataFile = FileInput.ReadAllLines(@"D:\Projects\learn_csharp\Shoping\Books.txt");
            _bookShop = new BookShop(bookDataFile);
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
