using Arcadia.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Arcadia.Repository
{
    public static class ArcadiaSeedData
    {
        public static void EnsureSeedData(this ArcadiaContext db)
        {
            // Companies
            var nintendo = new Company {Id = 1, Name = "Nintendo"};
            var sega = new Company { Id = 2, Name = "Sega" };

            var companies = new List<Company>
            {
                nintendo,
                sega
            };

            if (!db.Companies.Any())
            {
                db.Companies.AddRange(companies);
                db.SaveChanges();
            }

            // Games
            var superMarioBros = new Game{Id = 1,Name = "Super Mario Bros."};
            var theLeyendOfZelda = new Game { Id = 2, Name = "The Leyend of Zelda" };
            var sonic3D = new Game {Id = 3, Name = "Sonic 3D"};
            var superSmashBros = new Game { Id = 4, Name = "Super Smash Bros." };

            var games = new List<Game>
            {
                superMarioBros,
                theLeyendOfZelda ,
                sonic3D,
                superSmashBros
            };

            if (!db.Games.Any())
            {
                db.Games.AddRange(games);
                db.SaveChanges();
            }

            // Heroes
            var mario = new Hero
            {
                Id = 1,
                Name = "Mario",
                Games = new List<HeroGame>
                {
                    new HeroGame{Game = superMarioBros },
                    new HeroGame{Game = superSmashBros }
                },
                Company = nintendo
            };
            var link = new Hero
            {
                Id = 2,
                Name = "Link",
                Games = new List<HeroGame>
                {
                    new HeroGame{Game = theLeyendOfZelda },
                    new HeroGame{Game = superSmashBros }
                },
                Company = nintendo
            };
            var sonic = new Hero
            {
                Id = 3,
                Name = "Sonic",
                Games = new List<HeroGame>
                {
                    new HeroGame{Game = sonic3D },
                },
                Company = sega
            };
            var pikachu = new Hero
            {
                Id = 4,
                Name = "Pikachu",
                Games = new List<HeroGame>
                {
                    new HeroGame{Game = superSmashBros }
                },
                Company = nintendo
            };
            var heroes = new List<Hero>
            {
                mario,
                link,
                sonic,
                pikachu
            };
            if (!db.Heroes.Any())
            {
                db.Heroes.AddRange(heroes);
                db.SaveChanges();
            }
        }
    }
}
