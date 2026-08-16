using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIWithJenkins.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // A user is in many sales
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
