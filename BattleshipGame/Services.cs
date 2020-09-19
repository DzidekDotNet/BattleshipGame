using BattleshipGame.GameStates;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BattleshipGame
{
    internal static class Services
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>))
                .AddLogging(configure => configure.AddSerilog());
            services.AddGameStateServices();
        }
    }
}