using System;
using System.Text;
using System.Threading.Tasks;
using BattleshipGame.Games;
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
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                var newGameState = serviceProvider.GetService<NewGameState>();

                Game game = new Game(
                    newGameState, 
                    loggerFactory.CreateLogger<Game>());
                
                while (game.ShouldReadLineFromConsole)
                {
                    StringBuilder output = game.Print();
                    output.AppendLine(string.Empty);
                    await Console.Out.WriteAsync(output);
                    
                    string enteredData = Console.ReadLine();
                    Console.Clear();
                    game.Process(enteredData);
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