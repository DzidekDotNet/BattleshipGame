// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
//
// namespace BattleshipGame.Games
// {
//     internal class GameBoardDrawer : IGameBoardDrawer
//     {
//         public StringBuilder PrintBoard(IGameBoard board)
//         {
//             StringBuilder lineBreaker = GetLineBreaker(board.Size);
//
//             StringBuilder output = new StringBuilder();
//             output.Append(GenerateXAxisHeader(board.Size));
//             output.AppendLine();
//             output.Append(lineBreaker);
//             output.AppendLine();
//
//             for (byte i = 0; i < board.Size; i++)
//             {
//                 for (byte j = 0; j < board.Size; j++)
//                 {
//                     if (j == 0)
//                     {
//                         output.Append(GenerateYAxisHeader(i));
//                     }
//
//                     output.Append(GeneratePoint(j, i, board.GeneratedShips, board.Shoots));
//
//                     if (j == board.Size - 1)
//                     {
//                         output.AppendLine();
//                         output.Append(lineBreaker);
//                         output.AppendLine();
//                     }
//                 }
//             }
//
//             return output;
//         }
//
//         private StringBuilder GenerateXAxisHeader(byte size)
//         {
//             StringBuilder xAxisHeader = new StringBuilder();
//             for (byte i = 0; i < size + 1; i++)
//             {
//                 if (i == 0)
//                 {
//                     xAxisHeader.Append("   |");
//                 }
//                 else
//                 {
//                     //char 65 is A
//                     xAxisHeader.Append($" {((char) (i - 1 + 65))} |");
//                 }
//             }
//
//             return xAxisHeader;
//         }
//
//         private StringBuilder GetLineBreaker(byte size)
//         {
//             StringBuilder lineBreaker = new StringBuilder();
//             for (int i = 0; i < size + 1; i++)
//             {
//                 lineBreaker.Append("----");
//             }
//
//             return lineBreaker;
//         }
//
//         private StringBuilder GenerateYAxisHeader(byte position)
//         {
//             StringBuilder yAxisHeader = new StringBuilder();
//             yAxisHeader.Append($" {position + 1} |");
//
//             return yAxisHeader;
//         }
//
//         //Change to IsEqual and pass Point instead of x and y
//         private StringBuilder GeneratePoint(byte x, byte y, IList<GeneratedShip> generatedShips, IList<Point> shoots)
//         {
//             StringBuilder generatedPoint = new StringBuilder();
//             Point shoot = shoots.FirstOrDefault(p => p.X == x && p.Y == y);
//             if (shoot != null)
//             {
//                 if (generatedShips.Any(g => g.Points.Any(p => p.X == x && p.Y == y)))
//                 {
//                     generatedPoint.Append(" x |");
//                     //TODO this is hit - implement hit and sink
//                 }
//                 else
//                 {
//                     generatedPoint.Append(" o |");
//                 }
//             }
//
//             return generatedPoint;
//         }
//     }
// }