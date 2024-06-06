using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class AcademicProgram
    {
        [Key]
        public int ProgramId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public string Description { get; set; }

        public string AdmissionRequirements { get; set; }

        public string CurriculumDetails { get; set; }

        public string FacultyProfiles { get; set; }
    }
}
