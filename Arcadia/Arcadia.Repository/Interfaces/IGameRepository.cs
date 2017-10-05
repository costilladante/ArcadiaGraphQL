using System.Threading.Tasks;
using Arcadia.Repository.Models;

namespace Arcadia.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> Get(int id);
    }
}
