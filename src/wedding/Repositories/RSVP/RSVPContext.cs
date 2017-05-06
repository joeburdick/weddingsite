using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedding.Models;

namespace wedding.Repositories
{
    public class RSVPContext : DbContext, IRepository<RSVP>
    {
        public RSVPContext(DbContextOptions<RSVPContext> options) : base(options)
        {

        }

        private DbSet<RSVP> RSVPs { get; set; }

        public async Task AddAsync(RSVP item)
        {
            await RSVPs.AddAsync(item);
            await SaveChangesAsync();
        }

        public Task<RSVP> GetAsync(int id)
        {
            return RSVPs.FindAsync(id);
        }
    }
}
