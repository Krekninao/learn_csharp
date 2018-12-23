namespace Shopping
{
    public class Device: IDevice
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public int ProductIdentificator { get; set; }
        public string ProducingCountry { get; set; }

        public Device()
        {
            
        }

        public Device(string data)
        {
            var dataArray = data.Split(' ');
            ProductIdentificator = int.Parse(dataArray[0]);
            Name = dataArray[1];
            Price = float.Parse(dataArray[2]);
            Rating = int.Parse(dataArray[3]);
            ProducingCountry = dataArray[4];
        }

        public void Update(IDevice newProduct)
        {
            Name = newProduct.Name;
            Price = newProduct.Price;
            Rating = newProduct.Rating;
            ProducingCountry = newProduct.ProducingCountry;
        }

        public override string ToString()
        {
            return $"{Name} стоит {Price.ToString("F1")}$. Произведено в {ProducingCountry}";
        }

        
    }
}
