using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public string ContactInformation { get; set; }
    }
}
