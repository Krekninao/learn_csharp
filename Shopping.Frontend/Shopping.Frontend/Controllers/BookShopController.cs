using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shopping.ApplicationService;

namespace Shopping.Frontend.Controllers
{
    [Route("api/[controller]")]
    public class BookShopController: Controller
    {
        private readonly BookShopApplicationService _applicationService;
        public BookShopController(BookShopApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public List<IBook> GetBooks()
        {
            return _applicationService.GetBooks();
        }

        [HttpGet("{id}")]
        public IBook GetBook(int id)
        {
            return _applicationService.GetBook(id);
        }

        [HttpPost]
        public void AddBook([FromBody] Book book)
        {
            _applicationService.AddBook(book);
        }

        [HttpPut]
        public void UpdateBook([FromBody] Book newBook)
        {
            _applicationService.UpdateBook(newBook);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _applicationService.DeleteBook(id);
        }
    }
}
