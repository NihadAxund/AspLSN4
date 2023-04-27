namespace AspLesson4.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product()
        {

        }
        public void Changing(Product product)
        {
            Name = product.Name;
            Price = product.Price;

        }
    }
}
