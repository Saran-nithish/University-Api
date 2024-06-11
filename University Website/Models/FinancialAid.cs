using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class FinancialAid
    {
        [Key]
        public int AidId { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string EligibilityCriteria { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Deadline { get; set; }
    }
}
