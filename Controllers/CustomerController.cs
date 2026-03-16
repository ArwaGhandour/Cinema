using cinemasecondflutter.customrepos;
using cinemasecondflutter.DTOS;
using cinemasecondflutter.Genaricrepos;
using cinemasecondflutter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace cinemasecondflutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer _cust;
        private Imovies _mov;
        private IGenaric<Ticket> _ticketrepop;

       

        public CustomerController(ICustomer cust, Imovies mov, IGenaric<Ticket> ticketrepop)
        {
            _cust = cust;
            _mov = mov;
            _ticketrepop = ticketrepop;

        }
        [HttpPost]
        public async Task<IActionResult> addcustomer(addcust custdto)
        {
            if (custdto == null)
            {
                return BadRequest();
            }
            var allmovies = await _mov.Getall();
            var selected = allmovies.Where(x => custdto.movieidss.Contains(x.Id)).ToList();
            var newcustomer = new customer
            {
                EmailAddress = custdto.EmailAddress,
                Name = custdto.Name,
                ticket = new Ticket
                {
                    Price = custdto.tickett.Price,
                    SeatNumber = custdto.tickett.SeatNumber,
                    showtime = custdto.tickett.showtime,
                },
                movies = selected
            };
            await _cust.Addasync(newcustomer);
            return Ok(custdto);
        }
        [HttpGet]
        public async Task<IActionResult> getallcustom()
        {
            var allcust = await _cust.Getallcust();
            var dto = allcust.Select(x => new getcustwithdetails
            {
                EmailAddress = x.EmailAddress,
                Name = x.Name,
                tickett = new TicketDto
                {
                    Price = x.ticket.Price,
                    SeatNumber = x.ticket.SeatNumber,
                    showtime = x.ticket.showtime,
                },
                movieidss = x.movies.Select(x => x.Title).ToList()
            }).ToList();
            return Ok(dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updatecustomer(int id, addcust custdto)
        {
            var spec = await _cust.GetbyIDcust(id);
            if (spec == null)
            {
                return NotFound();
            }
            var allmovies = await _mov.Getall();
            var selected = allmovies.Where(x => custdto.movieidss.Contains(x.Id)).ToList();

            spec.EmailAddress = custdto.EmailAddress;
            spec.Name = custdto.Name;
            spec.ticket.Price = custdto.tickett.Price;
            spec.ticket.SeatNumber = custdto.tickett.SeatNumber;
            spec.ticket.showtime = custdto.tickett.showtime;
            spec.movies = selected;
            _cust.Updateasync(spec);
            return Ok(custdto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletecustomer(int id)
        {
            var spec = await _cust.GetbyIDcust(id);
              

            if (spec == null)
            {
                return NotFound();
            }
             
            _cust.Delete(id);
            return Ok();
        }
    }
}
