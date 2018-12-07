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

            //Assert.AreEqual("Misery", book.Name);
        }

        [Test]
        public void CheckBuyingBook()
        {
            var bookDataFile = File.ReadAllLines("Books.txt");
            var bookShop = new BookShop(bookDataFile);
            bookShop.BuyItem(1);
            Assert.AreEqual(3, bookShop.GetNumberOfItems());
        }

        [Test]
        public void CheckAddingDevice()
        {
            var deviceDataFile = File.ReadAllLines("Devices.txt");
            var deviceShop = new DeviceShop(deviceDataFile);
            var device = new Device(5, "GasCooker", 38.6, 49, "Italy");
            deviceShop.AddItem(device);
            Assert.AreEqual(5, deviceShop.GetNumberOfItems());
        }

        [Test]
        public void CheckNameOfBook()
        {
            var bookDataFile = File.ReadAllLines("Books.txt");
            var bookShop = new BookShop(bookDataFile);
            var book = new Book();
            book = (Book)bookShop.ShopItems[2];
            Assert.AreEqual("Carry", book.Name);
        }

        [Test]
        public void CheckNameOfProductCountry()
        {
            var deviceDataFile = File.ReadAllLines("Devices.txt");
            var deviceShop = new DeviceShop(deviceDataFile);
            var device = deviceShop.ShopItems[1];
            Assert.AreEqual("India", device.ProducingCountry);
        }
    }
}