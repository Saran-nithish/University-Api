using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class SearchHistory
    {
        [Key]
        public int SearchId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string SearchQuery { get; set; }

        public DateTime SearchDate { get; set; }

        public User User { get; set; }
    }
}
