using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcadia.API.Models;
using Arcadia.API.ModelTypes;
using GraphQL.Types;

namespace Arcadia.API.Queries
{
    public class ArcadiaQuery : ObjectGraphType
    {
        public ArcadiaQuery()
        {
            Field<HeroType>(
                "hero",
                resolve: context => new Hero { Id = 1, Name = "Mario"}
            );
        }
    }
}
