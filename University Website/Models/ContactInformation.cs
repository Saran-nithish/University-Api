using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class ContactInformation
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public Department Department { get; set; }
    }
}
