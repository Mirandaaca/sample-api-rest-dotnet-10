using System.ComponentModel.DataAnnotations;

namespace CIWithJenkins.Entities
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // A role is in many users
        public IEnumerable<User> Users = Enumerable.Empty<User>();
    }
}
