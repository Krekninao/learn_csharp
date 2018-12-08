namespace Shopping
{
    public interface IBook : IProduct
    {
        string Author { get; set; }
        void Update(IBook newBook);
    }
}
