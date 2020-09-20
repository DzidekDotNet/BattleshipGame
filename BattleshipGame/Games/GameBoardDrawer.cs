using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Games
{
    internal class GameBoardDrawer : IGameBoardDrawer
    {
        private readonly IShootChecker shootChecker;

        public GameBoardDrawer(IShootChecker shootChecker)
        {
            this.shootChecker = shootChecker;
        }

        public StringBuilder PrintBoard(IGameBoard board)
        {
            StringBuilder lineBreaker = GetLineBreaker(board.Size);

            StringBuilder output = new StringBuilder();
            output.Append(GenerateXAxisHeader(board.Size));
            output.AppendLine();
            output.Append(lineBreaker);
            output.AppendLine();

            for (byte y = 0; y < board.Size; y++)
            {
                for (byte x = 0; x < board.Size; x++)
                {
                    if (x == 0)
                    {
                        output.Append(GenerateYAxisHeader(y));
                    }

                    output.Append(GeneratePoint(new Point(x, y), board.GeneratedShips, board.Shoots));

                    if (x == board.Size - 1)
                    {
                        output.AppendLine();
                        output.Append(lineBreaker);
                        output.AppendLine();
                    }
                }
            }

            return output;
        }

        private StringBuilder GenerateXAxisHeader(byte size)
        {
            StringBuilder xAxisHeader = new StringBuilder();
            for (byte i = 0; i < size + 1; i++)
            {
                if (i == 0)
                {
                    xAxisHeader.Append("   |");
                }
                else
                {
                    //char 65 is A
                    xAxisHeader.Append($" {((char) (i - 1 + 65))} |");
                }
            }

            return xAxisHeader;
        }

        private StringBuilder GetLineBreaker(byte size)
        {
            StringBuilder lineBreaker = new StringBuilder();
            for (int i = 0; i < size + 1; i++)
            {
                lineBreaker.Append("----");
            }

            return lineBreaker;
        }

        private StringBuilder GenerateYAxisHeader(byte position)
        {
            StringBuilder yAxisHeader = new StringBuilder();
            yAxisHeader.Append($"{(position + 1).ToString().PadLeft(2)} |");

            return yAxisHeader;
        }

        private StringBuilder GeneratePoint(Point point, IList<GeneratedShip> generatedShips, IList<Point> shoots)
        {
            StringBuilder generatedPoint = new StringBuilder();
            ShootResult shootResult = shootChecker.CheckShot(point, generatedShips, shoots);
            switch (shootResult)
            {
                case ShootResult.Hit:
                    generatedPoint.Append(" x |");
                    break;
                case ShootResult.HitAndSink:
                case ShootResult.SinkAllShips:
                    generatedPoint.Append(" X |");
                    break;
                case ShootResult.Miss:
                    generatedPoint.Append(" o |");
                    break;
                default:
                    generatedPoint.Append("   |");
                    break;
            }

            return generatedPoint;
        }
    }
}