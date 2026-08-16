using CIWithJenkins.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIWithJenkins.Entities
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        // A sale has many sale details
        public IEnumerable<SaleDetail> SaleDetails { get; set; } = Enumerable.Empty<SaleDetail>();
        
    }
}
