using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hiroyukims.graphql.netcore.api;
using hiroyukims.graphql.netcore.api.Repository;
using hiroyukims.graphql.netcore.api.GraphQL;
using GraphQL.Types;
using GraphQL;

namespace hiroyukims.graphql.netcore.api.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WeatherForecastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new EatMoreQuery(_context)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}
