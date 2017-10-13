using System.Collections.Generic;
using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Arcadia.Repository.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private ArcadiaContext _db { get; }

        public HeroRepository(ArcadiaContext db)
        {
            _db = db;
        }

        public async Task<Hero> Get(int id)
        {
            return await _db.Heroes.FirstOrDefaultAsync(hero => hero.Id == id);
        }
    }
}
