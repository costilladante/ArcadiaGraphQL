using Arcadia.Repository.Models;
using GraphQL.Types;

namespace Arcadia.API.ModelTypes
{
    public class GameType : ObjectGraphType<Game>
    {
        public GameType()
        {
            Field(g => g.Id).Description("The ID of the Game.");
            Field(g => g.Name).Description("The name of the Game.");
        }
    }
}
