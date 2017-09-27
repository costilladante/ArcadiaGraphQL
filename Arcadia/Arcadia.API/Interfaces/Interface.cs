using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcadia.API.Models;

namespace Arcadia.API.Interfaces
{
    public interface IHeroRepository
    {
        Task<Hero> Get(int id);
    }
}
