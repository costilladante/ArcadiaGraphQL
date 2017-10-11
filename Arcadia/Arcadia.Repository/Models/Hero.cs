using System.Collections.Generic;

namespace Arcadia.Repository.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<HeroGame> Games { get; set; }
    }
}
