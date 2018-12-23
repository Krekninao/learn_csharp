namespace Shopping
{
    public interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        int Rating { get; set; }
        int ProductIdentificator { get; set; }

    }
}
