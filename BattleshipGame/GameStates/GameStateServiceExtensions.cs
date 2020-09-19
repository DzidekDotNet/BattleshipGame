using Microsoft.Extensions.DependencyInjection;

namespace BattleshipGame.GameStates
{
    internal static class GameStateServiceExtensions
    {
        internal static void AddGameStateServices(this IServiceCollection services)
        {
            services.AddTransient<NewGameState>();
            services.AddTransient<RunningGameState>();
            services.AddTransient<EndGameState>();
            services.AddTransient<EndedGameState>();
        }
    }
}