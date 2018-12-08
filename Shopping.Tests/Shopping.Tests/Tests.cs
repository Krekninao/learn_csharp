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
    }
}