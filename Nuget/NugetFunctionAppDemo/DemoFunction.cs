using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using ReaderNuget;

namespace FunctionAppNuget
{
    public static class DemoFunction
    {
        [FunctionName("DemoFunction")]
        public static async Task<IActionResult> RunDemoFunction(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(Reader.DecodeMultiple(10));
        }

        [FunctionName("DemoFunctionWithUsing")]
        public static async Task<IActionResult> RunDemoFunctionWithUsing(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(Reader.DecodeMultipleWithUsing(10));
        }
    }
}
