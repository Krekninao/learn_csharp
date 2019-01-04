using System.Collections.Generic;
using System.Linq;
using Shopping.DataAccess;

namespace Shopping.ApplicationService
{
    public class DeviceShopApplicationService
    {
        public List<Device> GetDevices()
        {
            using (var dbContext = new ShopContext())
            {
                return dbContext.Devices.ToList();
            }
        }

        public Device GetDevice(int id)
        {
            using (var dbContext = new ShopContext())
            {
                return dbContext.Devices.Single(b => b.ProductIdentificator == id);
            }
        }

        public void AddDevice(Device device)
        {
            using (var dbContext = new ShopContext())
            {
                dbContext.Devices.Add(new Device
                {
                    Price = device.Price,
                    Name = device.Name,
                    Rating = device.Rating,
                    ProducingCountry = device.ProducingCountry
                });
                dbContext.SaveChanges();
            }
        }

        public void UpdateDevice(Device device)
        {
            using (var dbContext = new ShopContext())
            {
                dbContext.Devices.Single(b => b.ProductIdentificator == device.ProductIdentificator).Update(device);

            }
        }

        public void DeleteDevice(int id)
        {
            using (var dbContext = new ShopContext())
            {
                var delDevice = dbContext.Books.Single(b => b.ProductIdentificator == id);
                dbContext.Books.Remove(delDevice);
            }
        }
    }
}
