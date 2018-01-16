using System.Collections.Generic;
using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

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

        public async Task<List<Hero>> GetAll()
        {
            return await _db.Heroes.ToListAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            var hero = await _db.Heroes.FirstOrDefaultAsync(h => h.Id == id);
            var company = await _db.Companies.FirstOrDefaultAsync(comp => comp.Id == hero.CompanyId);
            return company;
        }

        public async Task<Hero> Delete(int heroId)
        {
            var heroToDelete = await _db.Heroes.FirstOrDefaultAsync(c => c.Id == heroId);
            if (heroToDelete == null) throw new Exception($"Hero with id { heroId } not found.");
            _db.Heroes.Remove(heroToDelete);
            _db.SaveChanges();
            return heroToDelete;
        }

        public async Task<Hero> AddAsync(Hero newHero)
        {
            await _db.Heroes.AddAsync(newHero);
            _db.SaveChanges();
            return newHero;
        }

    }
}
