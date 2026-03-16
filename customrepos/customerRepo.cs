using cinemasecondflutter.Genaricrepos;
using cinemasecondflutter.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemasecondflutter.customrepos
{
    public class customerRepo : GenaricRepo<customer>, ICustomer
    {
        public customerRepo(AppDbcontext context) : base(context)
        {
        }

        public async Task<List<customer>> Getallcust()
        {
            return await _context.Customer.Include(x=>x.movies).Include(x=>x.ticket).ToListAsync();
        }

        public async Task<customer> GetbyIDcust(int id)
        {
            return await _context.Customer.Include(x => x.movies).Include(x => x.ticket).FirstOrDefaultAsync(x=>x.Id==id);

        }
    }
}
