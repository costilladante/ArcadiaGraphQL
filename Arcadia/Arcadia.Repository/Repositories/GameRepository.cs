using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<Game>> GetAll()
        {
            return _db.Games.ToListAsync();
        }

        public Task<Game> Get(int id)
        {
            return _db.Games.FirstOrDefaultAsync(game => game.Id == id);
        }

        public List<Game> GetAllByHeroId(int id)
        {
            var heroGames = _db.HeroGames.Where(hg => hg.HeroId == id).Include(g => g.Game);
            return heroGames.Select(g => g.Game).ToList();
        }
    }
}
