namespace ProductManager.Models
{
    public class ProductInputModel
    {
        public ProductInputModel(string? name, string? description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
