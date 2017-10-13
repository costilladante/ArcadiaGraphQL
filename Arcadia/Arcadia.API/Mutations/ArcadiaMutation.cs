using Arcadia.API.ModelTypes;
using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;
using GraphQL.Types;

namespace Arcadia.API.Mutations
{
    public class ArcadiaMutation : ObjectGraphType<object>
    {
        public ArcadiaMutation(ICompanyRepository companyRepository)
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
                    new QueryArgument<CompanyInputType>{ Name = "company"}
                ),
                resolve: context =>
                {
                    var company = context.GetArgument<Company>("company");
                    return companyRepository.AddAsync(company);
                }
            );

            Field<CompanyType>(
                "updateCompany",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<CompanyInputType> { Name = "company"}
                ),
                resolve: context =>
                {
                    var companyId = context.GetArgument<int>("id");
                    var company = context.GetArgument<Company>("company");
                    company.Id = 1;
                    return companyRepository.Update(companyId, company);
                }
            );
        }
    }
}
