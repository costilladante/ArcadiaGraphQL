using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Arcadia.Repository.Repositories
{
    public class GameRepository : IGameRepository
    {
        private ArcadiaContext _db { get; }

        public GameRepository(ArcadiaContext db)
        {
            _db = db;
        }

        public Task<Game> Get(int id)
        {
            return _db.Games.FirstOrDefaultAsync(game => game.Id == id);
        }
    }
}
