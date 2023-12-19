using Microsoft.Extensions.Configuration;
using Serilog.Sinks.File;
using Serilog;

namespace CommonUtility

{
    public class BookManagementLogger
    {
        public void BuildConfigure()
        {
            var configuration = new ConfigurationBuilder()
                           .AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration().
                    ReadFrom.Configuration(configuration)
                    .CreateLogger();
            




        }

    }
}