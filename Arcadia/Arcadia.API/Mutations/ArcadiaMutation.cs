using Arcadia.API.ModelTypes;
using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;
using GraphQL.Types;

namespace Arcadia.API.Mutations
{
    public class ArcadiaMutation : ObjectGraphType<object>
    {
        public ArcadiaMutation(ICompanyRepository companyRepository, IHeroRepository heroRepository)
        {
            /*
             Example of Mutation for company (create):

             mutation{
              createCompany(company: { name: "Atari"}){
                id
                name
              }
            }
             */
            Name = "Mutation";
            Field<CompanyType>(
                "createCompany",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CompanyInputType>>{ Name = "company"}
                ),
                resolve: context =>
                {
                    var company = context.GetArgument<Company>("company");
                    return companyRepository.AddAsync(company);
                }
            );

           Field<HeroType>(
           "createHero",
           arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<HeroInputType>> { Name = "hero" }
           ),
           resolve: context =>
           {
               var hero = context.GetArgument<Hero>("hero");
               return heroRepository.AddAsync(hero);
           }
       );


            Field<CompanyType>(
                "updateCompany",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<CompanyInputType>> { Name = "company"}
                ),
                resolve: context =>
                {
                    var companyId = context.GetArgument<int>("id");
                    var company = context.GetArgument<Company>("company");
                    return companyRepository.Update(companyId, company);
                }
            );

            Field<CompanyType>(
                "deleteCompany",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var companyId = context.GetArgument<int>("id");
                    return companyRepository.Delete(companyId);
                }
            );

            Field<HeroType>(
               "deleteHero",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
               ),
               resolve: context =>
               {
                   var heroId = context.GetArgument<int>("id");
                   return heroRepository.Delete(heroId);
               }
            );


        }
    }
}
