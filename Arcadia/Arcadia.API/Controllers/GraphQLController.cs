using Arcadia.API.Models;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Arcadia.API.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private IDocumentExecuter _documentExecuter { get; }
        private ISchema _schema { get; }
        
        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            try
            {
                if (query == null)
                {
                    throw new ArgumentException(nameof(query));
                }

                var result = await _documentExecuter.ExecuteAsync(_ =>
                {
                    _.Schema = _schema;
                    _.Query = query.Query;
                    _.Inputs = query.Variables.ToInputs();
                    _.OperationName = query.OperationName;
                }).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}