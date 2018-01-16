using System.Collections.Generic;
using Arcadia.Repository.Models;
using System.Threading.Tasks;

namespace Arcadia.Repository.Interfaces
{
    public interface IHeroRepository
    {
        Task<Hero> Get(int id);
        Task<List<Hero>> GetAll();
        Task<Company> GetCompany(int id);
        Task<Hero> Delete(int heroId);
        Task<Hero> AddAsync(Hero newHero);
    }
}
