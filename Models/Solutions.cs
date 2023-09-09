using System.ComponentModel.DataAnnotations;

namespace IssueTrackingSystem.Models
{
    public class Solutions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public int IssueId { get; set; }
        [Required]
        public string Issue { get; set; }
        [Required]
        public String Solution { get; set; }
        [Required]
        public String Admin { get; set; }
    }
}
