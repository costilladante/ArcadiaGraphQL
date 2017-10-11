using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;
using GraphQL.Types;

namespace Arcadia.API.ModelTypes
{
    public class HeroType : ObjectGraphType<Hero>
    {
        public HeroType(ICompanyRepository companyRepository )
        {
            Name = "Hero";
            Field(h => h.Id).Description("The ID of the Hero.");
            Field(h => h.Name).Description("The Name of the Hero.");
            Field<CompanyType>("company",
                resolve: context =>
                {
                    var companyId = context.Source.CompanyId;
                    return companyRepository.Get(companyId);
                }
            );
        }
    }
}
