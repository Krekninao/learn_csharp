namespace Shopping
{
    public class Book: IBook
    {



        public string Name { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }

        public Book()
        {

        }

        public Book(string Data)
        {
            var dataarray = Data.Split(' ');
            Id = int.Parse(dataarray[0]);
            Name = dataarray[1];
            Price = float.Parse(dataarray[2]);
            Rating = int.Parse(dataarray[3]);
            Author = dataarray[4];
        }

        public void Update(IBook newBook)
        {
            Name = newBook.Name;
            Price = newBook.Price;
            Rating = newBook.Rating;
            Author = newBook.Author;
        }

        public override string ToString()
        {
            return $"{Name}. Автор: {Author}. Стоимость: {Price}.";
        }
    }
}
