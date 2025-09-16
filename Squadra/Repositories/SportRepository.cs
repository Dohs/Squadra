using Microsoft.EntityFrameworkCore;
using Squadra.Data;
using Squadra.Models;

namespace Squadra.Repositories
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