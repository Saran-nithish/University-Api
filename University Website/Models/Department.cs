using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }


    }
}
