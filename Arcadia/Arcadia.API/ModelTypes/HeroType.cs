using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcadia.API.Models;
using GraphQL.Types;

namespace Arcadia.API.ModelTypes
{
    public class HeroType : ObjectGraphType<Hero>
    {
        public HeroType()
        {
            Field(x => x.Id).Description("The ID of the Hero.");
            Field(x => x.Name).Description("The Name of the Hero.");
        }
    }
}
