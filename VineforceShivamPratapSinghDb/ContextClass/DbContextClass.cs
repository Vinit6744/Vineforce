using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using VineforceShivamPratapSinghDb.Entitymodels;

namespace VineforceShivamPratapSinghDb.ContextClass
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
    }
}
