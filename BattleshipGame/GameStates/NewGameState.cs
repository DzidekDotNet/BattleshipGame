using System.Text;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.GameStates
{
    internal class NewGameState : BaseGameState
    {
        private readonly ILogger<NewGameState> logger;

        public NewGameState(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<NewGameState>();
        }

        public override bool ShouldReadLineFromConsole => true;

        public override StringBuilder Print()
        {
            logger.LogTrace("Printing in new game state");
            return new StringBuilder("Do you want to start playing in battleship game? (y or n)");
        }

        public override void Process(string enteredData)
        {
            logger.LogTrace("Processing in new game state. enteredData: '{enteredData}'", enteredData);
            IGameState nextGameState;
            if (enteredData.ToLower() == "y")
            {
                nextGameState = new RunningGameState();
            }
            else
            {
                nextGameState = new EndedGameState();
            }
            
            Game.TransitionTo(nextGameState);

            logger.LogDebug(
                "The new game state has been processed. enteredData: '{enteredData}', nextGameState: '{nextGameState}'",
                enteredData, nextGameState.GetType());
        }
    }
}