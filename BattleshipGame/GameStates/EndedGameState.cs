using System;
using System.Text;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.GameStates
{
    internal class EndedGameState : BaseGameState
    {
        public override bool ShouldReadLineFromConsole => false;

        private readonly ILogger<EndedGameState> logger;

        public EndedGameState(ILogger<EndedGameState> logger)
        {
            this.logger = logger;
        }

        public override StringBuilder Print()
        {
            logger.LogTrace("Printing in ended game state");
            return new StringBuilder();
        }

        public override StringBuilder Process(string enteredData)
        {
            logger.LogTrace("Processing in ended game state. enteredData: '{enteredData}'", enteredData);
            return new StringBuilder();
        }
    }
}