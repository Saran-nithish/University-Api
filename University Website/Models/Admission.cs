using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class Admission
    {
        [Key]
        public int AdmissionId { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [ForeignKey("Program")]
        public int ProgramId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        [Required]
        [StringLength(2000)]
        public string ApplicationFormData { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }
    }
}
