using Arcadia.Repository.Models;
using System.Linq;

namespace Arcadia.Repository.EFRepositories
{
    public static class ArcadiaSeedData
    {
        public static void EnsureSeedData(this ArcadiaContext db)
        {
            if (!db.Heroes.Any())
            {
                var hero = new Hero
                {
                    Name = "Mario"
                };
                db.Heroes.Add(hero);
                db.SaveChanges();
            }
        }
    }
}
