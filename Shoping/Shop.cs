using System.Collections.Generic;

namespace Shopping
{
     public abstract class Shop<T> where T: class 
     {
         public List<T> ShopItems { get; set; } //было - protected
         public abstract void ShowItems();
         public abstract void BuyItem(int id);
         public abstract void AddItem(T product);
     }
}
