using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FileInput = System.IO.File;

namespace Shopping.Frontend.Controllers
{
    [Route("api/[controller]")]
    public class DeviceShopController : Controller
    {
        private DeviceShop _deviceShop;
        public DeviceShopController()
        {
            var deviceDataFile = FileInput.ReadAllLines(@"D:\Projects\learn_csharp\Shoping\Devices.txt");
            _deviceShop = new DeviceShop(deviceDataFile);
        }

        [HttpGet]
        public List<IDevice> GetBooks()
        {
            return _deviceShop.GetItems();
        }

        [HttpGet("{id}")]
        public IDevice GetBook(int id)
        {
            return _deviceShop.GetItem(id);
        }

        [HttpPost]
        public List<IDevice> AddBook([FromBody] Device device)
        {

            _deviceShop.AddItem(device);
            return _deviceShop.GetItems();
        }

        [HttpPut]
        public List<IDevice> UpdateBook([FromBody] Device newDevice)
        {
            _deviceShop.UpdateItem(newDevice);
            return _deviceShop.GetItems();
        }

        [HttpDelete("{id}")]
        public List<IDevice> DeleteBook(int id)
        {
            _deviceShop.Remove(id);
            return _deviceShop.GetItems();
        }
    }
}
