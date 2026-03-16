
using Microsoft.EntityFrameworkCore;

namespace cinemasecondflutter.Genaricrepos
{
    public class GenaricRepo<T> : IGenaric<T> where T : class
    {
        protected AppDbcontext _context;

        public GenaricRepo(AppDbcontext context)
        {
            _context = context;
        }

        public async Task Addasync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
           var dele=await _context.Set<T>().FindAsync(id);
            if (dele != null) { 
              _context.Set<T>().Remove(dele);
                await _context.SaveChangesAsync();
            
            }
        }

        public async Task<List<T>> Getall()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetbyID(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async void Updateasync(T entity)
        {
             _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
