using AzureFunctionsWithDI.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

// This assembly-level attribute defines the startup for our functions application.
[assembly: FunctionsStartup(typeof(AzureFunctionsWithDI.Startup))]

namespace AzureFunctionsWithDI
{
    /// <summary>
    /// The <see cref="Startup"/> class inherits from the <see cref="FunctionsStartup"/> class, which takes care of many things for us.
    /// </summary>
    public class Startup : FunctionsStartup
    {
        /// <summary>
        /// The method in which we configure all our services to be injected.
        /// </summary>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Add two or our own custom services to demonstrate injection with different service lifetimes.
            builder.Services.AddSingleton<MyAService>();
            builder.Services.AddTransient<MyBService>();
        }
    }
}
