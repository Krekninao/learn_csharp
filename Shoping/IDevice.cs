using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping
{
    interface IDevice : IProduct
    {
        string ProducingCountry { get; set; }
    }
}
