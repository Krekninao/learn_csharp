using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shopping.DataAccess;

namespace Shopping.ApplicationService
{
    class DeviceShopApplicationService
    {
        private readonly IServiceProvider _provider;

        public DeviceShopApplicationService(IServiceProvider provider)
        {
            _provider = provider;
        }
        public List<Device> GetDevices()
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                return dbContext.Devices.ToList();
            }
        }

        public Device GetDevice(int id)
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                return dbContext.Devices.Single(b => b.ProductIdentificator == id);
            }
        }

        public void AddDevice(Device device)
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
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
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                dbContext.Devices.Single(b => b.ProductIdentificator == device.ProductIdentificator).Update(device);

            }
        }

        public void DeleteDevice(int id)
        {
            using (var dbContext = new ShopContext(_provider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                var delDevice = dbContext.Books.Single(b => b.ProductIdentificator == id);
                dbContext.Books.Remove(delDevice);
            }
        }
    }
}
