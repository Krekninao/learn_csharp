using System;
using System.IO;
using NUnit.Framework;

namespace Shopping.Tests
{
    [TestFixture]
    public class Tests
    {
        private BookShop _bookShop;
        private DeviceShop _deviceShop;

        [SetUp]
        public void SetUp()
        {
            var bookDataFile = File.ReadAllLines("BooksTest.txt");
            _bookShop = new BookShop(bookDataFile);

            var deviceDataFile = File.ReadAllLines("DeviceTest.txt");
            _deviceShop = new DeviceShop(deviceDataFile);
        }

        [Test]
        public void CheckNumberOfBooks()
        {
            Assert.AreEqual(1, _bookShop.GetNumberOfItems());
        }
        [Test]
        public void CheckNumberOfDevices()
        {
            Assert.AreEqual(1, _deviceShop.GetNumberOfItems());
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
        public void CheckBuyingDevice()
        {
            var device = _deviceShop.BuyItem(1);
            Assert.AreEqual(0, _deviceShop.GetNumberOfItems());
            Assert.AreEqual("WashingMachine", device.Name);
            Assert.AreEqual(75, device.Price);
            Assert.AreEqual(13, device.Rating);
            Assert.AreEqual("China", device.ProducingCountry);
        }
        [Test]
        public void CheckAddingBook()
        {
            var newBook = new Book
            {
                Id = 2,
                Name = "In a beautiful and furious world",
                Author = "Platonov",
                Price = 26.7,
                Rating = 68
            };
            _bookShop.AddItem(newBook);
            Assert.AreEqual(2, _bookShop.GetNumberOfItems());
            var receivedBook = _bookShop.BuyItem(newBook.Id);
            Assert.AreEqual("In a beautiful and furious world", receivedBook.Name);
            Assert.AreEqual(26.7, receivedBook.Price);
            Assert.AreEqual(68, receivedBook.Rating);
            Assert.AreEqual("Platonov", receivedBook.Author);
        }
        [Test]
        public void CheckAddingDevice()
        {
            var newDevice = new Device
            {
                Id = 2,
                Name = "GasCooker",
                ProducingCountry = "Italy",
                Price = 38.6,
                Rating = 49
            };
            _deviceShop.AddItem(newDevice);
            Assert.AreEqual(2, _deviceShop.GetNumberOfItems());
            var receivedDevice = _deviceShop.BuyItem(newDevice.Id);
            Assert.AreEqual("GasCooker", receivedDevice.Name);
            Assert.AreEqual(38.6, receivedDevice.Price);
            Assert.AreEqual(49, receivedDevice.Rating);
            Assert.AreEqual("Italy", receivedDevice.ProducingCountry);
        }

        [Test]
        public void CheckRemovingBook()
        {
            _bookShop.Remove(1);
            Assert.AreEqual(0, _bookShop.GetNumberOfItems());
            Assert.Throws(typeof(InvalidOperationException), () => { _bookShop.GetItem(1); });
        }
        [Test]
        public void CheckRemovingDevice()
        {
            _deviceShop.Remove(1);
            Assert.AreEqual(0, _deviceShop.GetNumberOfItems());
            Assert.Throws(typeof(InvalidOperationException), () => { _deviceShop.GetItem(1); });
        }
        [Test]
        public void CheckUpdatingBook()
        {
            var newBook = new Book
            {
                Id = 1,
                Name = "In a beautiful and furious world",
                Author = "Platonov",
                Price = 26.7,
                Rating = 68
            };
            _bookShop.UpdateItem(newBook);
            Assert.AreEqual(1, _bookShop.GetNumberOfItems());
            var receivedBook = _bookShop.GetItem(newBook.Id);
            Assert.AreEqual("In a beautiful and furious world", receivedBook.Name);
            Assert.AreEqual(26.7, receivedBook.Price);
            Assert.AreEqual(68, receivedBook.Rating);
            Assert.AreEqual("Platonov", receivedBook.Author);
        }
        [Test]
        public void CheckUpdatingDevice()
        {
            var newDevice = new Device
            {
                Id = 1,
                Name = "GasCooker",
                ProducingCountry = "Italy",
                Price = 38.6,
                Rating = 49
            };
            _deviceShop.UpdateItem(newDevice);
            Assert.AreEqual(1, _deviceShop.GetNumberOfItems());
            var receivedDevice = _deviceShop.GetItem(newDevice.Id);
            Assert.AreEqual("GasCooker", receivedDevice.Name);
            Assert.AreEqual(38.6, receivedDevice.Price);
            Assert.AreEqual(49, receivedDevice.Rating);
            Assert.AreEqual("Italy", receivedDevice.ProducingCountry);
        }
    }
}