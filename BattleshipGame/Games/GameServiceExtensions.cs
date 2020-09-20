using Microsoft.Extensions.DependencyInjection;

namespace BattleshipGame.Games
{
    internal static class GameServiceExtensions
    {
        internal static void AddGameServices(this IServiceCollection services)
        {
            services.AddTransient<IShipCoordinatesGenerator, ShipRandomCoordinatesGenerator>();
            services.AddTransient<IGameBoardDrawer, GameBoardDrawer>();
            services.AddTransient<IShootChecker, ShootChecker>();
            services.AddTransient<IGameBoard, GameBoard>();
        }
    }
}