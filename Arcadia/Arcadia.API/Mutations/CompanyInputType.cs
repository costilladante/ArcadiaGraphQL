using GraphQL.Types;

namespace Arcadia.API.Mutations
{
    public class CompanyInputType: InputObjectGraphType
    {
        public CompanyInputType()
        {
            Name = "CompanyInput";
            Field<NonNullGraphType<IntGraphType>>("id"); // TODO: REMOVE THIS. Id must not be required. It needs to be resolved by generating a new ID in the Add/Update function from the CompanyRepository.
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
