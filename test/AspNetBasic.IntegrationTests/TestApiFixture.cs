using System;
using System.Threading.Tasks;
using AspNetBasic.WebApi;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace AspNetBasic.IntegrationTests
{
    public class TestApiFixture : IDisposable
    {
        private IHost _api1;

        public TestApiFixture()
        {
            
        }

        public async Task LaunchApi(ITestOutputHelper logger)
        {
            var hostBuilder = Program.CreateHostBuilder(new string[] { });
            hostBuilder.ConfigureLogging((_, logging) =>
                {

                    logging.ClearProviders();
                    logging.AddProvider(new XUnitLoggerProvider(logger));
                }
            );

            _api1 = hostBuilder.Build();

            await _api1.StartAsync();

        }

        public void Dispose()
        {
            _api1?.StopAsync().Wait();
            _api1?.Dispose();
        }
    }

    [CollectionDefinition(nameof(TestApiCollection))]
    public class TestApiCollection : ICollectionFixture<TestApiFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }




}