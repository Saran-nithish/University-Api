using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [ForeignKey("AcademicProgram")]
        public int ProgramId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }

        public AcademicProgram AcademicProgram { get; set; }
        public Faculty Faculty { get; set; }
    }
}
