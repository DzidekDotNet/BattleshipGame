using System;
using System.Text;
using BattleshipGame.Games;
using BattleshipGame.GameStates;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.GameStates
{
    [UnitTest]
    public class RunningGameStateTest
    {
        private readonly RunningGameState target;
        private readonly Mock<IGame> gameMock;
        private readonly Mock<IShootChecker> shootCheckerMock;
        private readonly Mock<IServiceProvider> serviceProviderMock;
        
        public RunningGameStateTest()
        {
            gameMock = new Mock<IGame>();

            serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock
                .Setup(x => x.GetService(It.IsAny<Type>()))
                .Returns(new EndGameState(serviceProviderMock.Object, NullLogger<EndGameState>.Instance));

            Mock<IGameBoardDrawer> boardDrawerMock = new Mock<IGameBoardDrawer>();
            boardDrawerMock
                .Setup(x => x.PrintBoard(It.IsAny<IGameBoard>()))
                .Returns(new StringBuilder("board"));
            
            shootCheckerMock = new Mock<IShootChecker>();
            
            target = new RunningGameState(serviceProviderMock.Object, boardDrawerMock.Object, shootCheckerMock.Object,
                NullLogger<RunningGameState>.Instance);
        }

        [Fact]
        public void ShouldReadLineFromConsole_ForRunningGameState_ShouldReturnTrue()
        {
            Assert.True(target.ShouldReadLineFromConsole);
        }
        
        [Fact]
        public void Print_Always_BoardAndAskAboutNextMove()
        {
            target.SetGameContext(gameMock.Object);

            StringBuilder result = target.Print();
            
            Assert.Equal("boardEnter a shot coordinates and press Enter:", result.ToString());
        }
        
        [Fact]
        public void Process_WhenMiss_PrintMissInformation()
        {
            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IGameBoard>()))
                .Returns(ShootResult.Miss);
            target.SetGameContext(gameMock.Object);

            StringBuilder result = target.Process("A3");
            
            Assert.Equal($"You miss{Environment.NewLine}", result.ToString());
        }
        
        [Fact]
        public void Process_WhenHit_PrintHitInformation()
        {
            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IGameBoard>()))
                .Returns(ShootResult.Hit);
            target.SetGameContext(gameMock.Object);

            StringBuilder result = target.Process("A3");
            
            Assert.Equal($"You hit{Environment.NewLine}", result.ToString());
        }
        
        [Fact]
        public void Process_WhenHitAndSink_PrintHitAndSinkInformation()
        {
            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IGameBoard>()))
                .Returns(ShootResult.HitAndSink);
            target.SetGameContext(gameMock.Object);

            StringBuilder result = target.Process("A3");
            
            Assert.Equal($"You hit and sink{Environment.NewLine}", result.ToString());
        }
        
        [Fact]
        public void Process_WhenWrongShoot_PrintWrongShootInformation()
        {
            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IGameBoard>()))
                .Returns(ShootResult.WrongShoot);
            target.SetGameContext(gameMock.Object);

            StringBuilder result = target.Process("A3");
            
            Assert.Equal($"Wrong coordinates. Try again.{Environment.NewLine}", result.ToString());
        }
        
        [Fact]
        public void Process_WhenSinkAllShips_PrintSinkAllShipsInformationAndChangeState()
        {
            IGameState gameState = null;
            gameMock
                .Setup(x => x.TransitionTo(It.IsAny<IGameState>()))
                .Callback<IGameState>((state) => { gameState = state; });

            shootCheckerMock
                .Setup(x => x.CheckShot(It.IsAny<Point>(), It.IsAny<IGameBoard>()))
                .Returns(ShootResult.SinkAllShips);
            target.SetGameContext(gameMock.Object);

            StringBuilder result = target.Process("A3");
            
            Assert.Equal($"You sink all ships{Environment.NewLine}", result.ToString());
            gameMock.Verify(x => x.TransitionTo(It.IsAny<IGameState>()));
            Assert.IsType<EndGameState>(gameState);
        }
    }
}