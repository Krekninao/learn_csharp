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
            foreach (var shopItem in ShopItems)
            {
                Console.WriteLine(shopItem.ToString());
            }
        }

        public override void BuyItem(int id)
        {
            foreach (var book in ShopItems)
            {
                if (book.Id == id)
                {
                    ShopItems.Remove(book);
                    Console.WriteLine($"Вы купили {book.Name}. Спасибо за покупку! Заходите к нам ещё!");
                    break;
                }
            }

        }

        public override void AddItem(IBook product)
        {
            ShopItems.Add(product);
        }
    }
}
