using System.Collections.Generic;

namespace Shopping
{
     abstract class Shop<T> where T: class 
     {
         protected List<T> ShopItems { get; set; }
         public abstract void ShowItems();
         public abstract void BuyItem(int id);
         public abstract void AddItem(T product);
     }
}
