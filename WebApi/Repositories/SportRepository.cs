using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class SportRepository : ISportRepository
    {
        private readonly ApplicationDbContext _context;

        public SportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sport>> GetAllAsync()
        {
            return await _context.Sports.ToListAsync();
        }
    }
}