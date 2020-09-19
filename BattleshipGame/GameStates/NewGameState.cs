using System;
using System.Text;
using BattleshipGame.Games;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.GameStates
{
    internal class NewGameState : BaseGameState
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IShipGenerator shipGenerator;
        private readonly ILogger<NewGameState> logger;

        public NewGameState(IServiceProvider serviceProvider, IShipGenerator shipGenerator,
            ILogger<NewGameState> logger)
        {
            this.serviceProvider = serviceProvider;
            this.shipGenerator = shipGenerator;
            this.logger = logger;
        }

        public override bool ShouldReadLineFromConsole => true;

        public override StringBuilder Print()
        {
            logger.LogTrace("Printing in new game state");
            return new StringBuilder("Do you want to start playing in battleship game? (y or n)");
        }

        public override StringBuilder Process(string enteredData)
        {
            logger.LogTrace("Processing in new game state. enteredData: '{enteredData}'", enteredData);
            IGameState nextGameState;
            if (enteredData.ToLower() == "y")
            {
                Game.SetGeneratedShips(shipGenerator.GenerateShips(Game.Board.Size, ))
                nextGameState = serviceProvider.GetService<RunningGameState>();
            }
            else
            {
                nextGameState = serviceProvider.GetService<EndedGameState>();
            }

            Game.TransitionTo(nextGameState);

            logger.LogDebug(
                "The new game state has been processed. enteredData: '{enteredData}', nextGameState: '{nextGameState}'",
                enteredData, nextGameState.GetType());
            return new StringBuilder();
        }
    }
}