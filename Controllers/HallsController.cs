using cinemasecondflutter.DTOS;
using cinemasecondflutter.Genaricrepos;
using cinemasecondflutter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cinemasecondflutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly IGenaric<Hall> _hall;

        public HallsController(IGenaric<Hall> hall)
        {
            _hall = hall;
        }

        [HttpPost]
        public async Task<IActionResult> Addhall(HalllDto hallsdto)
        {
            if (hallsdto == null)
            {
                return NotFound();
            }
            var hall = new Hall
            {
                Capacity = hallsdto.Capacity,
                Name = hallsdto.Name,
            };
            await _hall.Addasync(hall);
            return Ok(hall);

        }
    }
}
