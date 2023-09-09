using System.ComponentModel.DataAnnotations;

namespace IssueTrackingSystem.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int count { get; set; }

    }
}
