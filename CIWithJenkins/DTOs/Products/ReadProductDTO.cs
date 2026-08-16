namespace CIWithJenkins.DTOs.Products
{
    public class ReadProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
    }
}
