using cinemasecondflutter.customrepos;
using cinemasecondflutter.DTOS;
using cinemasecondflutter.Genaricrepos;
using cinemasecondflutter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cinemasecondflutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly Imovies _mov;
        private readonly IGenaric<Hall> _hall;

        public MovieController(Imovies mov, IGenaric<Hall> hall)
        {
            _mov = mov;
            _hall = hall;
        }
        [HttpPost]
        public async Task<IActionResult>Addnewmovie(addnewmovie movdto)
        {
            var allhall=await _hall.GetbyID(movdto.hallid);
            if (allhall == null)
            {
                return BadRequest();
            }
            if (movdto == null)
            {
                return BadRequest();

            }
            var mov = new Movie
            {
                Duration = movdto.Duration,
                Title = movdto.Title,
                HallId = movdto.hallid,
            };
            await _mov.Addasync(mov);
            return Ok(movdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getmov(int id)
        {
            var allmov = await _mov.getbyidwith(id);
            if (allmov == null)
            {
                return NotFound();
            }
            var movdto = new readmovie
            {
                Duration = allmov.Duration,
                Title = allmov.Title,
                hallid = allmov.hall.Name,
            };
            return Ok(movdto);
        }

        }
}
