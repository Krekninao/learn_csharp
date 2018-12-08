namespace Shopping
{
    public interface IDevice : IProduct
    {
        string ProducingCountry { get; set; }
        void Update(IDevice newProduct);
    }
}
