using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class Admission
    {
        [Key]
        public int AdmissionId { get; set; }

        [Required]
        [ForeignKey("AcademicProgram")]
        public int ProgramId { get; set; }

        public string Instructions { get; set; }

        public string Deadlines { get; set; }

        public string ApplicationFormLink { get; set; }

        public string TuitionFees { get; set; }

        public AcademicProgram AcademicProgram { get; set; }
    }
}
