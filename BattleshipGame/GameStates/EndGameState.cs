using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.GameStates
{
    internal class EndGameState : BaseGameState
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<EndGameState> logger;
        public override bool ShouldReadLineFromConsole => true;


        public EndGameState(IServiceProvider serviceProvider, ILogger<EndGameState> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public override StringBuilder Print()
        {
            logger.LogTrace("Printing in end game state");
            return new StringBuilder("You win, you are awesome. Press any key to end.");
        }

        public override StringBuilder Process(string enteredData)
        {
            logger.LogTrace("Processing in end game state. enteredData: '{enteredData}'", enteredData);
            Game.TransitionTo(serviceProvider.GetService<EndedGameState>());
            return new StringBuilder();
        }
    }
}