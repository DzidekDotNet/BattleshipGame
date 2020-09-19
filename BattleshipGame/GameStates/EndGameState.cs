using System;
using System.Text;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.GameStates
{
    internal class EndGameState : BaseGameState
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger<EndGameState> logger;
        public override bool ShouldReadLineFromConsole => true;


        public EndGameState(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            logger = loggerFactory.CreateLogger<EndGameState>();
        }

        public override StringBuilder Print()
        {
            logger.LogTrace("Printing in end game state");
            return new StringBuilder("You win, you are awesome. Press any key to end.");
        }

        public override void Process(string enteredData)
        {
            logger.LogTrace("Processing in end game state. enteredData: '{enteredData}'", enteredData);
            Game.TransitionTo(new EndedGameState(loggerFactory.CreateLogger<EndedGameState>()));
        }
    }
}