using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsWithDI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class MyAService : ServiceBase
    {
        public MyAService(IConfiguration configuration, ILogger<MyAService> logger) : base(configuration, logger)
        {
            this.Logger?.LogDebug($"Created new instance of the {this.GetType().FullName} service.");
        }

    }
}
