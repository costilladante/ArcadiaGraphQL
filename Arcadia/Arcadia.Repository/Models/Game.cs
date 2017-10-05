using System.Collections.Generic;

namespace Arcadia.Repository.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HeroGame> Heroes { get; set; }
    }
}
