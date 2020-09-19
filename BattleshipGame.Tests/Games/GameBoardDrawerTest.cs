// using System.Collections.Generic;
// using System.Text;
// using BattleshipGame.Games;
// using Moq;
// using Xunit;
//
// namespace BattleshipGame.Tests.Games
// {
//     public class GameBoardDrawerTest
//     {
//         
//         [Theory]
//         [InlineData(2, @"   | A | B |
// ------------
// 1 |
// ------------
// 2 |
// ------------
// Enter a shot point and press Enter:")]
//         [InlineData(3, @"   | A | B | C |
// ----------------
// 1 |    
// ----------------
// 2 |    
// ----------------
// 3 |    
// ----------------
// Enter a shot point and press Enter:")]
//         [InlineData(5, "")]
//         public void Print_WhenBoardIsEmpty_ShouldPrintEmptyBoardAndQuestionForMove(byte boardSize, string expectedResalt)
//         {
//             Mock<IGameBoard> gameBoardMock = new Mock<IGameBoard>();
//             gameBoardMock
//                 .SetupGet(x => x.Size)
//                 .Returns(boardSize);
//             gameBoardMock
//                 .SetupGet(x => x.GeneratedShips)
//                 .Returns(new List<GeneratedShip>());
//             gameBoardMock
//                 .SetupGet(x => x.Shoots)
//                 .Returns(new List<Point>());
//             gameMock
//                 .SetupGet(x => x.Board)
//                 .Returns(gameBoardMock.Object);
//
//             target.SetGameContext(gameMock.Object);
//
//             StringBuilder result = target.Print();
//             
//             Assert.Equal(expectedResalt, result.ToString());
//         }
//         
//         [Theory]
//         [ClassData(typeof(RunningGameStateTest_Print_WhenBoardIsEmptyAndShipsAreGenerated))]
//         internal void Print_WhenBoardIsEmptyAndShipsAreGenerated_ShouldPrintEmptyBoardAndQuestionForMove(byte boardSize, IList<GeneratedShip> generatedShips, string expectedResalt)
//         {
//             Mock<IGameBoard> gameBoardMock = new Mock<IGameBoard>();
//             gameBoardMock
//                 .SetupGet(x => x.Size)
//                 .Returns(boardSize);
//             gameMock
//                 .SetupGet(x => x.Board)
//                 .Returns(gameBoardMock.Object);
//
//             target.SetGameContext(gameMock.Object);
//
//             StringBuilder result = target.Print();
//             
//             Assert.Equal(expectedResalt, result.ToString());
//         }
//     }
// }
//
