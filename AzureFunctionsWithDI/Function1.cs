using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureFunctionsWithDI.Services;
using Microsoft.Extensions.Configuration;

namespace AzureFunctionsWithDI
{
    public class Function1
    {
        public Function1(IConfiguration configuration, MyAService singleton, MyBService transient)
        {
            // Azure Functions runtime now supports instance methods in order to support DI (since version 2.0.12265).

            this.Configuration = configuration;

            this.Singleton = singleton;
            this.Transient = transient;
        }

        private readonly IConfiguration Configuration;
        private readonly MyAService Singleton;
        private readonly MyBService Transient;

        [FunctionName("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger log)
        {

            // Returning the instance IDs of the two injected services to demonstrate their lifetime.
            return new ContentResult()
            {
                Content = $"Singleton instance ID: {this.Singleton.GetInstanceId()}\nTransient instance ID: {this.Transient.GetInstanceId()}",
                StatusCode = 200
            };
        }
    }
}
