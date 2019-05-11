using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsWithDI.Services
{
    public class MyBService : ServiceBase
    {
        public MyBService(IConfiguration configuration, ILogger<MyBService> logger) : base(configuration, logger)
        {
            this.Logger?.LogDebug($"Created new instance of the {this.GetType().FullName} service.");
        }

    }
}
