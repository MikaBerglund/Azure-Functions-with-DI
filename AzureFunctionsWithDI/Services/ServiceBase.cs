using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsWithDI.Services
{
    /// <summary>
    /// A base class for handling common things in our services.
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        /// </summary>
        /// <remarks>
        /// Specify the services we want subclasses to depend on.
        /// </remarks>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        protected ServiceBase(IConfiguration configuration, ILogger logger)
        {
            this.Configuration = configuration;
            this.Logger = logger;
        }

        protected IConfiguration Configuration { get; private set; }
        protected ILogger Logger { get; private set; }


        private Guid _InstanceId = Guid.NewGuid();

        public Guid GetInstanceId()
        {
            return _InstanceId;
        }

    }
}
