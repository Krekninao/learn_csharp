using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping
{
    interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        int Rating { get; set; }
        int Id { get; set; }
    }
}
