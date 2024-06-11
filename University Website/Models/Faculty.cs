using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Photo { get; set; }

        public string ContactInformation { get; set; }

        public string Expertise { get; set; }

        public string OfficeHours { get; set; }

    }
}
