using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Content { get; set; }

        public DateTime DateSubmitted { get; set; }

        public string ResponseStatus { get; set; }

        public DateTime ResponseDate { get; set; }

    }
}
