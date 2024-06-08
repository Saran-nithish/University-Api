using System.ComponentModel.DataAnnotations;

namespace University_Website.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string Location { get; set; }

        public string RegistrationLink { get; set; }
    }
}
