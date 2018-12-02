using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Shopping.Tests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void CheckNumberOfBooks()
        {
            var bookDataFile = File.ReadAllLines("Books.txt");
            var bookShop = new BookShop(bookDataFile);
            var book = new Book();
            Assert.AreEqual(4, bookShop.GetNumberOfItems());

            Assert.AreEqual("Misery", book.Name);
        }
    }
}