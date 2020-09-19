using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleshipGame.Games;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.GameStates
{
    internal class RunningGameState : BaseGameState
    {
        public override bool ShouldReadLineFromConsole => true;

        private readonly IServiceProvider serviceProvider;
        private readonly IGameBoardDrawer boardDrawer;
        private readonly IShootChecker shootChecker;
        private readonly ILogger<RunningGameState> logger;

        public RunningGameState(IServiceProvider serviceProvider, IGameBoardDrawer boardDrawer,
            IShootChecker shootChecker, ILogger<RunningGameState> logger)
        {
            this.serviceProvider = serviceProvider;
            this.boardDrawer = boardDrawer;
            this.shootChecker = shootChecker;
            this.logger = logger;
        }

        public override StringBuilder Print()
        {
            logger.LogTrace("Printing in running game state");
            StringBuilder sb = boardDrawer.PrintBoard(Game.Board);
            sb.Append("Enter a shot coordinates and press Enter:");
            return sb;
        }

        public override StringBuilder Process(string enteredData)
        {
            throw new NotImplementedException();
        }

        
    }
}