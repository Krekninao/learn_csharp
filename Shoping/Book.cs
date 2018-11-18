using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping
{
    class Book: IBook
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public string Author { get; set; }
        public Book(string Data)
        {
            var dataarray = Data.Split(' ');
            Name = dataarray[0];
            Price = float.Parse(dataarray[1]);
            Rating = int.Parse(dataarray[2]);
            Author = dataarray[3];
            Id = int.Parse(dataarray[4]);
        }


        
    }
}
