using System;
using System.Text;
using System.Threading.Tasks;
using BattleshipGame.GameStates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BattleshipGame
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //In production application we should add configuration to read settings from Development|Production file.
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("loggerSettings.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                var serviceCollection = new ServiceCollection();
                Services.ConfigureServices(serviceCollection);
                var serviceProvider = serviceCollection.BuildServiceProvider();
                var logger = serviceProvider.GetService<ILogger<Game>>();

                Game game = new Game(new NewGameState(), logger);
                while (game.ShouldReadLineFromConsole)
                {
                    StringBuilder output = game.Print();
                    await Console.Out.WriteAsync(output);
                    game.Process(Console.ReadLine());
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}