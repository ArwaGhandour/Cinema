using System.ComponentModel.DataAnnotations;

namespace cinemasecondflutter.Models
{
    public class Hall
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        public List<Movie>? movies { get; set; }
    }
}
