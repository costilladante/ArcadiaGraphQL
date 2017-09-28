using Arcadia.API.ModelTypes;
using Arcadia.Repository.Interfaces;
using GraphQL.Types;


namespace Arcadia.API.Queries
{
    public class ArcadiaQuery : ObjectGraphType
    {
        public ArcadiaQuery(IHeroRepository _heroRepository)
        {
            Field<HeroType>(
                "hero",
                resolve: context => _heroRepository.Get(1) // new Hero { Id = 1, Name = "Mario"}
            );
        }
    }
}
