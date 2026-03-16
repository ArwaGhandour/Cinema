using System.ComponentModel.DataAnnotations;

namespace cinemasecondflutter.DTOS
{
    public class HalllDto
    {
       
            public string Name { get; set; }
            public int Capacity { get; set; }
        
    }
    public class addcust
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }
        public TicketDto tickett { get; set; }
        public List<int> movieidss { get;set; }
    }
    public class TicketDto
    {
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime showtime { get; set; }
    }
    public class getcustwithdetails
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }
        public TicketDto tickett { get; set; }
        public List<string> movieidss { get; set; }
    }
    public class addnewmovie
    {
        public string Title { get; set; }
       
        public int Duration { get; set; }
        public int hallid { get;set; }
    }
    public class readmovie
    {
        public string Title { get; set; }

        public int Duration { get; set; }
        public string hallid { get; set; }
    }

}
