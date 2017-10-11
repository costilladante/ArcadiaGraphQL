using Arcadia.Repository.Models;
using GraphQL.Types;

namespace Arcadia.API.ModelTypes
{
    public class CompanyType : ObjectGraphType<Company>
    {
        public CompanyType()
        {
            Name = "Company";
            Field(c => c.Id).Description("The ID of the company.");
            Field(c => c.Name).Description("The Name of the company.");
        }
    }
}
