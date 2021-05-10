using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace AspNetBasic.IntegrationTests
{
    public class TestUtils
    {
        public static void WaitFor(Func<bool> predicate, int milliseconds = 5_000, string message = "")
        {
            var time = new Stopwatch();
            time.Start();
            var done = predicate();
            while (!done)
            {
                Task.Delay(100).Wait();
                done = predicate();
                done = done || time.ElapsedMilliseconds > milliseconds;
            }
            Assert.True(predicate(), message);
        }

        public static async Task WaitForAsync(Func<Task<bool>> predicate, int milliseconds = 5_000, string message = "")
        {
            var time = new Stopwatch();
            time.Start();
            var done = await predicate();
            while (!done)
            {
                await Task.Delay(100);
                done = await predicate();
                done = done || time.ElapsedMilliseconds > milliseconds;
            }
            Assert.True(await predicate(), message);
        }
    }
}