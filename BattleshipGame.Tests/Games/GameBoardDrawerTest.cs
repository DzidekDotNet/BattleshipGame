using System.Collections.Generic;
using System.Text;
using BattleshipGame.Games;
using Moq;
using Xunit;

namespace BattleshipGame.Tests.Games
{
    public class GameBoardDrawerTest
    {
        private readonly GameBoardDrawer target;
        private readonly Mock<IShootChecker> shootCheckerMock;

        public GameBoardDrawerTest()
        {
            shootCheckerMock = new Mock<IShootChecker>();
            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IList<GeneratedShip>>(), It.IsAny<IList<Point>>()))
                .Returns(ShootResult.WrongShoot);

            target = new GameBoardDrawer(shootCheckerMock.Object);
        }

        [Theory]
        [InlineData(2, @"   | A | B |
------------
 1 |   |   |
------------
 2 |   |   |
------------
")]
        [InlineData(3, @"   | A | B | C |
----------------
 1 |   |   |   |
----------------
 2 |   |   |   |
----------------
 3 |   |   |   |
----------------
")]
        public void PrintBoard_WhenBoardIsEmpty_ShouldPrintEmptyBoard(byte boardSize,
            string expectedResalt)
        {
            Mock<IGameBoard> gameBoardMock = new Mock<IGameBoard>();
            gameBoardMock
                .SetupGet(x => x.Size)
                .Returns(boardSize);
            gameBoardMock
                .SetupGet(x => x.GeneratedShips)
                .Returns(new List<GeneratedShip>());
            gameBoardMock
                .SetupGet(x => x.Shoots)
                .Returns(new List<Point>());

            StringBuilder result = target.PrintBoard(gameBoardMock.Object);

            Assert.Equal(expectedResalt, result.ToString());
        }

        [Theory]
        [ClassData(typeof(GameBoardDrawerTest_PrintBoard_WhenBoardIsEmptyAndShipsAreGenerated))]
        internal void PrintBoard_WhenBoardIsEmptyAndShipsAreGenerated_ShouldPrintEmptyBoard(
            byte boardSize, IList<GeneratedShip> generatedShips, string expectedResalt)
        {
            Mock<IGameBoard> gameBoardMock = new Mock<IGameBoard>();
            gameBoardMock
                .SetupGet(x => x.Size)
                .Returns(boardSize);
            gameBoardMock
                .SetupGet(x => x.GeneratedShips)
                .Returns(new List<GeneratedShip>()
                    {new GeneratedShip(new Battleship(), new List<Point>() {new Point(0, 0)})});
            gameBoardMock
                .SetupGet(x => x.Shoots)
                .Returns(new List<Point>());

            StringBuilder result = target.PrintBoard(gameBoardMock.Object);

            Assert.Equal(expectedResalt, result.ToString());
        }
        
        [Theory]
        [InlineData(2, @"   | A | B |
------------
 1 | o | o |
------------
 2 | o | o |
------------
")]
        [InlineData(3, @"   | A | B | C |
----------------
 1 | o | o | o |
----------------
 2 | o | o | o |
----------------
 3 | o | o | o |
----------------
")]
        public void PrintBoard_WhenBoardHasAllMiss_ShouldPrintMissBoard(byte boardSize,
            string expectedResalt)
        {
            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IList<GeneratedShip>>(), It.IsAny<IList<Point>>()))
                .Returns(ShootResult.Miss);
            
            Mock<IGameBoard> gameBoardMock = new Mock<IGameBoard>();
            gameBoardMock
                .SetupGet(x => x.Size)
                .Returns(boardSize);
            gameBoardMock
                .SetupGet(x => x.GeneratedShips)
                .Returns(new List<GeneratedShip>());
            gameBoardMock
                .SetupGet(x => x.Shoots)
                .Returns(new List<Point>());

            StringBuilder result = target.PrintBoard(gameBoardMock.Object);

            Assert.Equal(expectedResalt, result.ToString());
        }
        
        [Theory]
        [InlineData(2, @"   | A | B |
------------
 1 | x | x |
------------
 2 | x | x |
------------
")]
        [InlineData(3, @"   | A | B | C |
----------------
 1 | x | x | x |
----------------
 2 | x | x | x |
----------------
 3 | x | x | x |
----------------
")]
        public void PrintBoard_WhenBoardHasAllHit_ShouldPrintHitBoard(byte boardSize,
            string expectedResalt)
        {
            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IList<GeneratedShip>>(), It.IsAny<IList<Point>>()))
                .Returns(ShootResult.Hit);
            
            Mock<IGameBoard> gameBoardMock = new Mock<IGameBoard>();
            gameBoardMock
                .SetupGet(x => x.Size)
                .Returns(boardSize);
            gameBoardMock
                .SetupGet(x => x.GeneratedShips)
                .Returns(new List<GeneratedShip>());
            gameBoardMock
                .SetupGet(x => x.Shoots)
                .Returns(new List<Point>());

            StringBuilder result = target.PrintBoard(gameBoardMock.Object);

            Assert.Equal(expectedResalt, result.ToString());
        }
        
        [Theory]
        [InlineData(2, @"   | A | B |
------------
 1 | X | X |
------------
 2 | X | X |
------------
")]
        [InlineData(3, @"   | A | B | C |
----------------
 1 | X | X | X |
----------------
 2 | X | X | X |
----------------
 3 | X | X | X |
----------------
")]
        public void PrintBoard_WhenBoardHasAllHitAndSink_ShouldPrintHitAndSinkBoard(byte boardSize,
            string expectedResalt)
        {
            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IList<GeneratedShip>>(), It.IsAny<IList<Point>>()))
                .Returns(ShootResult.HitAndSink);
            
            Mock<IGameBoard> gameBoardMock = new Mock<IGameBoard>();
            gameBoardMock
                .SetupGet(x => x.Size)
                .Returns(boardSize);
            gameBoardMock
                .SetupGet(x => x.GeneratedShips)
                .Returns(new List<GeneratedShip>());
            gameBoardMock
                .SetupGet(x => x.Shoots)
                .Returns(new List<Point>());

            StringBuilder result = target.PrintBoard(gameBoardMock.Object);

            Assert.Equal(expectedResalt, result.ToString());
        }
    }
}