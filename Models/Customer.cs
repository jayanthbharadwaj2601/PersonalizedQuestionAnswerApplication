using System.ComponentModel.DataAnnotations;

namespace IssueTrackingSystem.Models
{
    public class Customer
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
