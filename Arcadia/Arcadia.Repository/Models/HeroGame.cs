namespace Arcadia.Repository.Models
{
    public class HeroGame
    {
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
