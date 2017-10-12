using GraphQL.Types;

namespace Arcadia.API.Mutations
{
    public class CompanyInputType: InputObjectGraphType
    {
        public CompanyInputType()
        {
            Name = "CompanyInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
