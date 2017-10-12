using System.Collections.Generic;
using System.Threading.Tasks;
using Arcadia.Repository.Models;

namespace Arcadia.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> Get(int id);
        Task<List<Game>> GetAllByHeroId(int id);
        Task<List<Game>> GetAll();
    }
}
