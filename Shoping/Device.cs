namespace Shopping
{
    class Device: IDevice
    {
       
        public Device(string data)
        {
            var dataArray = data.Split(' ');
            Id = int.Parse(dataArray[0]);
            Name = dataArray[1];
            Price = float.Parse(dataArray[2]);
            Rating = int.Parse(dataArray[3]);
            ProducingCountry = dataArray[4];
        }

        public Device(int id, string name, double price, int rating, string producingCountry)
        {
            Id = id;
            Name = name;
            Price = price;
            Rating = rating;
            ProducingCountry = producingCountry;
        }

        public override string ToString()
        {
            return $"{Name} стоит {Price.ToString("F1")}$. Произведено в {ProducingCountry}";
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }
        public string ProducingCountry { get; set; }
    }
}
