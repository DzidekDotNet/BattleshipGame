using System;
using System.Text;
using BattleshipGame.Games;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

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
            StringBuilder output = new StringBuilder();
            try
            {
                Point shootCoordinates = ParseEnteredDataToPoint(enteredData);

                ShootResult shootResult = shootChecker.CheckShot(shootCoordinates, Game.Board);
                switch (shootResult)
                {
                    case ShootResult.Hit:
                        output.AppendLine("You hit");
                        return output;
                    case ShootResult.Miss:
                        output.AppendLine("You miss");
                        return output;
                    case ShootResult.HitAndSink:
                        output.AppendLine("You hit and sink");
                        return output;
                    case ShootResult.SinkAllShips:
                        output.AppendLine("You sink all ships");
                        Game.TransitionTo(serviceProvider.GetService<EndGameState>());
                        return output;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
            }

            output.AppendLine("Wrong coordinates. Try again.");
            return output;
        }

        private Point ParseEnteredDataToPoint(string enteredData)
        {
            byte x = (byte) (((byte) enteredData[0]) - 65 + 1);
            byte y = byte.Parse(enteredData.Substring(1));
            
            return new Point(x, y);
        }
    }
}