using System.ComponentModel.DataAnnotations;

namespace cinemasecondflutter.Models
{
    public class customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public List<Movie>? movies { get; set; }
        public Ticket? ticket { get; set; }
        

    }
}
