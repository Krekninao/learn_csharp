using System.Collections.Generic;

namespace Shopping
{
     public abstract class Shop<T> where T: class 
     {
         protected List<T> ShopItems { get; set; }
         public abstract void ShowItems();
         public abstract T BuyItem(int id);
         public abstract void AddItem(T product);
     }
}
