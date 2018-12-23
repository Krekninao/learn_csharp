using System;
using System.IO;
using NUnit.Framework;

namespace Shopping.Tests
{
    [TestFixture]
    public class Tests
    {
        private BookShop _bookShop;

        [SetUp]
        public void SetUp()
        {
            var bookDataFile = File.ReadAllLines("BooksTest.txt");
            _bookShop = new BookShop(bookDataFile);
        }

        [Test]
        public void CheckNumberOfBooks()
        {
            Assert.AreEqual(1, _bookShop.GetNumberOfItems());
        }
        
        [Test]
        public void CheckBuyingBook()
        {
            var book = _bookShop.BuyItem(1);
            Assert.AreEqual(0, _bookShop.GetNumberOfItems());
            Assert.AreEqual("Misery", book.Name);
            Assert.AreEqual(50, book.Price);
            Assert.AreEqual(30, book.Rating);
            Assert.AreEqual("King", book.Author);
        }
       
        [Test]
        public void CheckAddingBook()
        {
            var newBook = new Book
            {
                Name = "In a beautiful and furious world",
                Author = "Platonov",
                Price = 26.7,
                Rating = 68
            };
            _bookShop.AddItem(newBook);
            Assert.AreEqual(2, _bookShop.GetNumberOfItems());
            var receivedBook = _bookShop.BuyItem(newBook.ProductIdentificator);
            Assert.AreEqual("In a beautiful and furious world", receivedBook.Name);
            Assert.AreEqual(26.7, receivedBook.Price);
            Assert.AreEqual(68, receivedBook.Rating);
            Assert.AreEqual("Platonov", receivedBook.Author);
        }
       

        [Test]
        public void CheckRemovingBook()
        {
            _bookShop.Remove(1);
            Assert.AreEqual(0, _bookShop.GetNumberOfItems());
            Assert.Throws(typeof(InvalidOperationException), () => { _bookShop.GetItem(1); });
        }
        
        [Test]
        public void CheckUpdatingBook()
        {
            var newBook = new Book
            {
                ProductIdentificator = 1,
                Name = "In a beautiful and furious world",
                Author = "Platonov",
                Price = 26.7,
                Rating = 68
            };
            _bookShop.UpdateItem(newBook);
            Assert.AreEqual(1, _bookShop.GetNumberOfItems());
            var receivedBook = _bookShop.GetItem(newBook.ProductIdentificator);
            Assert.AreEqual("In a beautiful and furious world", receivedBook.Name);
            Assert.AreEqual(26.7, receivedBook.Price);
            Assert.AreEqual(68, receivedBook.Rating);
            Assert.AreEqual("Platonov", receivedBook.Author);
        }
        
    }
}