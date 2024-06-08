using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class StudentResource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactInformation { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }
    }
}
