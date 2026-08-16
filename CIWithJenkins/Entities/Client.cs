using System.ComponentModel.DataAnnotations;

namespace CIWithJenkins.Entities
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
        // A client is in many sales
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
