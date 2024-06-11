using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DatePublished { get; set; }

        [ForeignKey("User")]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

    }
}
