using System.ComponentModel.DataAnnotations;

namespace IssueTrackingSystem.Models
{
    public class Issues
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String issue { get; set; }
        [Required]
        public String username { get; set; }
        [Required]
        public String Solution { get; set; }
    }
}
