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
        }
    }
}
