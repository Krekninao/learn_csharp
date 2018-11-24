using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping
{
    class DeviceShop : Shop<IDevice>
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

        public override void BuyItem(int id)
        {
            foreach (var device in ShopItems)
            {
                if (device.Id == id)
                {
                    ShopItems.Remove(device);
                    Console.WriteLine($"Вы купили {device.Name}. Спасибо за покупку! Заходите к нам ещё!");
                    break;
                }
            }
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
    }
}
