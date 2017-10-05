using Arcadia.API.Models;
using Arcadia.API.Queries;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arcadia.API.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private ArcadiaQuery _arcadiaQuery { get; }

        public GraphQLController(ArcadiaQuery arcadiaQuery)
        {
            _arcadiaQuery = arcadiaQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema {Query = _arcadiaQuery};

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}