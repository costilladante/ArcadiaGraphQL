using Arcadia.Repository.Models;
using System.Threading.Tasks;

namespace Arcadia.Repository.Interfaces
{
    public interface IHeroRepository
    {
        Task<Hero> Get(int id);
    }
}
