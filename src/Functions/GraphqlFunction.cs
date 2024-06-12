using HotChocolate.AzureFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Users.Functions
{
    public static class GraphqlFunction
    {

        [FunctionName("GraphqlFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "graphql")] HttpRequest req,
            [GraphQL] IGraphQLRequestExecutor executor,
            ILogger log
        )
        {
            log.LogInformation("C# 99 GraphQL trigger function processed a request.");

            return await executor.ExecuteAsync(req);
        }
    }
}
