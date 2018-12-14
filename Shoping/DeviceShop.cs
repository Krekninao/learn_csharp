using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping
{
    public class DeviceShop : Shop<IDevice>
    {
        public DeviceShop(string[] devicesData)
        {
            ShopItems = new List<IDevice>();
            foreach (var deviceData in devicesData)
            {
                var device = new Device(deviceData);
                ShopItems.Add(device);
            }
        }
        public override void ShowItems()
        {
            foreach (var shopItem in ShopItems)
            {
                Console.WriteLine(shopItem.ToString());
            }
        }

        public override IDevice BuyItem(int id)
        {
            var device = ShopItems.Single(s => s.Id == id);
            Console.WriteLine($"Вы купили {device}");
            ShopItems.Remove(device);
            return device;
        }

        

        public List<string> ShowProductCountry()
        {
            var ListOfProductCountry = new List<string>();
            foreach ( var device in ShopItems)
            {
                ListOfProductCountry.Add(device.ProducingCountry);
            }

            return ListOfProductCountry;
        }
        public override void AddItem(IDevice product)
        {
            ShopItems.Add(product);
        }

        public override IDevice GetItem(int id)
        {
            return ShopItems.Single(s => s.Id == id);
        }

        public override void Remove(int id)
        {
            ShopItems.Remove(ShopItems.Single(s => s.Id == id));
        }

        public override void UpdateItem(IDevice newItem)
        {
            ShopItems.Single(s => s.Id == newItem.Id).Update(newItem);
        }

        public int GetNumberOfItems()
        {
            return ShopItems.Count();
        }
    }
}
