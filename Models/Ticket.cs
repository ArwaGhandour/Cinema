using System.ComponentModel.DataAnnotations;

namespace cinemasecondflutter.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string SeatNumber { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime showtime { get; set; }
        public int CustomerId { get; set; }
        public customer? customers { get; set; }

    }
}
