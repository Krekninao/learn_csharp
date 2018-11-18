using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping
{
    interface IBook : IProduct
    {
        string Author { get; set; }
    }
}
