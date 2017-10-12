using Arcadia.API.ModelTypes;
using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;
using GraphQL.Types;

namespace Arcadia.API.Mutations
{
    public class ArcadiaMutation : ObjectGraphType<object>
    {
        public ArcadiaMutation(IHeroRepository heroRepository, ICompanyRepository companyRepository)
        {
            /*
             Example of Mutation for company (create):

             mutation{
              createCompany(company: {id: 5, name: "Sony"}){
                id
                name
              }
            }

             */
            Name = "Mutation";
            Field<CompanyType>(
                "createCompany",
                arguments: new QueryArguments(
                    new QueryArgument<CompanyInputType>{ Name = "company", DefaultValue = null}
                ),
                resolve: context =>
                {
                    var company = context.GetArgument<Company>("company");
                    return companyRepository.Add(company);
                }
            );
        }
    }
}
