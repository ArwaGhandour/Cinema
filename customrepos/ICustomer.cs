using cinemasecondflutter.Genaricrepos;
using cinemasecondflutter.Models;

namespace cinemasecondflutter.customrepos
{
    public interface ICustomer:IGenaric<customer>
    {
        public Task<List<customer>> Getallcust();
        public Task<customer> GetbyIDcust(int id);
    }
}
