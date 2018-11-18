using System.Collections.Generic;

namespace Shopping
{
     abstract class Shop<T> where T: class 
     {
         protected List<T> ShopItems { get; set; }
         public abstract List<T> ShowItems();
         public abstract T BuyItem();
         public abstract void AddItem(T product);
     }
}
