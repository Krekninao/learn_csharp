using System;
using System.Collections.Generic;
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
        public override List<IBook> ShowItems()
        {
            throw new NotImplementedException();
        }

        public override IBook BuyItem()
        {
            throw new NotImplementedException();
        }

        public override void AddItem(IBook product)
        {
            throw new NotImplementedException();
        }
    }
}
