using GraphQL.Types;

namespace Arcadia.API.Mutations
{
    public class HeroInputType : InputObjectGraphType
    {
        public HeroInputType()
        {
            Name = "HeroInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
