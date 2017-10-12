using Arcadia.API.ModelTypes;
using Arcadia.Repository.Interfaces;
using GraphQL.Types;


namespace Arcadia.API.Queries
{
    public class ArcadiaQuery : ObjectGraphType
    {
        public ArcadiaQuery(IHeroRepository heroRepository)
        {
            Name = "Query";
            Field<HeroType>(
                "hero",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id", Description = "ID of the hero."}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return heroRepository.Get(id);
                }
            );
        }
    }
}
