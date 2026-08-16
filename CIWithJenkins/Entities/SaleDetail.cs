using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIWithJenkins.Entities
{
    public class SaleDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
