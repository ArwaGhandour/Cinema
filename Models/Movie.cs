using System.ComponentModel.DataAnnotations;

namespace cinemasecondflutter.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public int Duration { get; set; }
        public List<customer>? customers { get; set; }
        public int HallId { get; set; }
        public Hall? hall { get; set; }
    }
}
