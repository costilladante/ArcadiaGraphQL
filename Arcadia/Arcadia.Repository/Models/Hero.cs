﻿using System.Collections.Generic;

namespace Arcadia.Repository.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company CreatedBy { get; set; }
        public ICollection<HeroGame> AppearsIn { get; set; }
    }
}
