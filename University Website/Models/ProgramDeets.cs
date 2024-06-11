using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class ProgramDeets
    {
        [Key]
        public int ProgramId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AdmissionRequirements { get; set; }

        [Required]
        public string CurriculumDetails { get; set; }

        [Required]
        public string FacultyProfiles { get; set; }
    }
}
