using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping
{
    public class BookShop : Shop<IBook>
    {
        public BookShop(string[] booksData)
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

        public override IBook BuyItem(int id)
        {
            var book = ShopItems.Single(s => s.Id == id);
            Console.WriteLine($"Вы купили {book}");
            ShopItems.Remove(book);
            return book;
        }

        public override void AddItem(IBook product)
        {
            ShopItems.Add(product);
        }

        public override IBook GetItem(int id)
        {
            return ShopItems.Single(s => s.Id == id); ;
        }

        public override void Remove(int id)
        {
            ShopItems.Remove(ShopItems.Single(s => s.Id == id));
        }

        public override void UpdateItem(IBook newItem)
        {
            ShopItems.Single(s => s.Id == newItem.Id).Update(newItem);
        }

        public int GetNumberOfItems()
        {
            return ShopItems.Count;
        }
    }
}
