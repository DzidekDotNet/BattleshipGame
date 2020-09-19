using System;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace BattleshipGame.GameStates
{
    internal class RunningGameState: BaseGameState
    {
        public override bool ShouldReadLineFromConsole => true;

        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<RunningGameState> logger;

        public RunningGameState(IServiceProvider serviceProvider, ILogger<RunningGameState> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }
        public override StringBuilder Print()
        {
            throw new System.NotImplementedException();
        }

        public override void Process(string enteredData)
        {
            throw new System.NotImplementedException();
        }
    }
}