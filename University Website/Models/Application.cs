using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("AcademicProgram")]
        public int ProgramId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime ReviewDate { get; set; }

        public DateTime DecisionDate { get; set; }

        public User User { get; set; }
        public AcademicProgram AcademicProgram { get; set; }
    }
}
