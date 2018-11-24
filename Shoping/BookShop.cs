using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping
{
    class BookShop : Shop<IBook>
    {
        public BookShop(string [] booksData)
        {
            ShopItems = new List<IBook>();
            foreach (var bookData in booksData)
            {
                var book = new Book(bookData);
                ShopItems.Add(book);
            }
        }
        public override void ShowItems()
        {
            var descriptions = ShopItems.Select(s => s.ToString());
            foreach (var description in descriptions)
            {
                Console.WriteLine(description);
            }
        }

        public override void BuyItem(int id)
        {
            var device = ShopItems.Single(s => s.Id == id);
            Console.WriteLine($"Вы купили {device}");
            ShopItems.Remove(device);
        }

        public override void AddItem(IBook product)
        {
            ShopItems.Add(product);
        }
    }
}
