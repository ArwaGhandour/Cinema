using cinemasecondflutter.Genaricrepos;
using cinemasecondflutter.Models;

namespace cinemasecondflutter.customrepos
{
    public interface Imovies:IGenaric<Movie>
    {
        public Task<Movie> getbyidwith(int id);
    }
}
