using System;
using System.IO;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookDataFile = File.ReadAllLines("Books.txt");
            var bookShop = new BookShop(bookDataFile);
            var deviceDataFile = File.ReadAllLines("Devices.txt");
            var deviceShop = new DeviceShop(deviceDataFile);
            deviceShop.ShowItems();
            deviceShop.BuyItem(1);
            var coffeeMaker = new Device(5, "CoffeeMaker", 45.5f, 31, "Bangladesh");
            deviceShop.AddItem(coffeeMaker);
            
            Console.WriteLine("Список стран-производителей:");
            foreach (var country in deviceShop.ShowProductCountry())
            {
                Console.WriteLine(country);
            }
            Console.ReadKey();
        }
    }
}
