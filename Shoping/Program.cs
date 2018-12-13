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
            
            bookShop.ShowItems();
            bookShop.Remove(3);
            bookShop.ShowItems();

            Console.ReadKey();

            
        }
    }
}
