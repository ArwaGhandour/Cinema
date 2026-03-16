using cinemasecondflutter.Genaricrepos;
using cinemasecondflutter.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemasecondflutter.customrepos
{
    public class movierepo : GenaricRepo<Movie>, Imovies
    {
        public movierepo(AppDbcontext context) : base(context)
        {
        }

        public async Task<Movie> getbyidwith(int id)
        {
            return await _context.Movie.Include(x => x.hall).FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
