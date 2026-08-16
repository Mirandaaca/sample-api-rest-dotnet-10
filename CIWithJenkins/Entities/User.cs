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
        public IEnumerable<Sale> Sales { get; set; } = Enumerable.Empty<Sale>();
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
