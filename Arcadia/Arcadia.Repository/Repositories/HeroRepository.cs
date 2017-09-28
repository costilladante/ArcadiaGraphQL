using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;

namespace Arcadia.Repository.Repositories
{
    public class HeroRepository: IHeroRepository
    {
        private readonly List<Hero> _heroes = new List<Hero>
        {
            new Hero{Id = 1, Name = "Mario"}
        };

        public Task<Hero> Get(int id)
        {
            return Task.FromResult(_heroes.FirstOrDefault(hero => hero.Id == id));
        }
    }
}
