using Arcadia.API.ModelTypes;
using Arcadia.Repository.Interfaces;
using GraphQL.Types;


namespace Arcadia.API.Queries
{
    public class ArcadiaQuery : ObjectGraphType
    {
        public ArcadiaQuery(IHeroRepository heroRepository, ICompanyRepository companyRepository, IGameRepository gameRepository)
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


            Field<CompanyType>(
               "company",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "ID of the company." }),
               resolve: context =>
               {
                   var id = context.GetArgument<int>("id");
                   return heroRepository.GetCompany(id);
               }
           );

            Field<ListGraphType<HeroType>>(
               "allHeroes",
               resolve: context => heroRepository.GetAll()
           );

            Field<ListGraphType<CompanyType>>(
                "allCompanies",
                resolve: context => companyRepository.GetAll()
            );

            Field<ListGraphType<GameType>>(
                "allGames",
                resolve: context => gameRepository.GetAll()
            );
        }
    }
}
