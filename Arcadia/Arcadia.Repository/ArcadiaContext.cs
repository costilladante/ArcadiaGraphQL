using System;
using System.Collections.Generic;
using System.Text;
using Arcadia.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Arcadia.Repository
{
    public class ArcadiaContext : DbContext
    {
        public ArcadiaContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
