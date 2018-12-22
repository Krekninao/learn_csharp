using System;
using System.IO;
using NUnit.Framework;

namespace Shopping.Tests
{
    [TestFixture]
    public class DeviceTests
    {
        private DeviceShop _deviceShop;

        [SetUp]
        public void SetUp()
        {
            var deviceDataFile = File.ReadAllLines("DeviceTest.txt");
            _deviceShop = new DeviceShop(deviceDataFile);
        }

        [Test]
        public void CheckNumberOfDevices()
        {
            Assert.AreEqual(1, _deviceShop.GetNumberOfItems());
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
        public void CheckAddingDevice()
        {
            var newDevice = new Device
            {
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
        public void CheckRemovingDevice()
        {
            _deviceShop.Remove(1);
            Assert.AreEqual(0, _deviceShop.GetNumberOfItems());
            Assert.Throws(typeof(InvalidOperationException), () => { _deviceShop.GetItem(1); });
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