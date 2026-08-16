using System.ComponentModel.DataAnnotations;

namespace CIWithJenkins.Entities
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // A client is in many sales
        public IEnumerable<Sale> Sales { get; set; } = Enumerable.Empty<Sale>();
    }
}
