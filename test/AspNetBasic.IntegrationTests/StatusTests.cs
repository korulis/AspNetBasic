using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AspNetBasic.IntegrationTests
{

    [Collection(nameof(TestApiCollection))]

    public class StatusTests : IDisposable
    {
        private readonly ITestOutputHelper _logger;
        private readonly TestApiFixture _testApiFixture;

        public StatusTests(ITestOutputHelper logger, TestApiFixture testApiFixture)
        {
            _logger = logger;
            _testApiFixture = testApiFixture;
            DotNetEnv.Env.Load(".env");
        }

        [Fact]
        public async Task ReturnsFriendlyMessage()
        {
            _logger.WriteLine(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            await _testApiFixture.LaunchApi(_logger);
            TestUtils.WaitFor(() => IsStatusFriendlyYet().Result, 10_000, "please");

            Assert.True(true);
            await Task.CompletedTask;
        }

        private static async Task<bool> IsStatusFriendlyYet()
        {
            using var client = new HttpClient();
            using var message = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/api/status");
            using var response = await client.SendAsync(message);

            if (!response.IsSuccessStatusCode) return false;

            var content = await response.Content.ReadAsStringAsync();
            var isStatusFriendlyYet = content.Contains("hello", StringComparison.InvariantCultureIgnoreCase);
            return isStatusFriendlyYet;

        }

        public void Dispose()
        {
            _testApiFixture?.Dispose();
        }

    }
}
