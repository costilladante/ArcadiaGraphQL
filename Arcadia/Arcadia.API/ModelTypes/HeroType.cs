using Arcadia.Repository.Models;
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
