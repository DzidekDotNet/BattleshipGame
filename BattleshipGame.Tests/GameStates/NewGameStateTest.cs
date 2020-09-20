using System;
using System.Collections.Generic;
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
    public class NewGameStateTest
    {
        private readonly NewGameState target;
        private readonly Mock<IGame> gameMock;
        private readonly Mock<IShipCoordinatesGenerator> shipCoordinatesGeneratorMock;

        public NewGameStateTest()
        {
            gameMock = new Mock<IGame>();
            Mock<IGameBoard> gameBoardMock = new Mock<IGameBoard>();
            gameBoardMock.SetupGet(x => x.Size).Returns(10);
            gameMock.SetupGet(x => x.Board).Returns(gameBoardMock.Object);

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock
                .Setup(x => x.GetService(It.IsAny<Type>()))
                .Returns<Type>((serviceType) => (serviceType == typeof(RunningGameState)
                    ? (IGameState) new RunningGameState(null, null, null, NullLogger<RunningGameState>.Instance)
                    : (IGameState) new EndedGameState(NullLogger<EndedGameState>.Instance)));

            shipCoordinatesGeneratorMock = new Mock<IShipCoordinatesGenerator>();

            target = new NewGameState(serviceProviderMock.Object, shipCoordinatesGeneratorMock.Object,
                NullLogger<NewGameState>.Instance);
        }

        [Fact]
        public void ShouldReadLineFromConsole_ForNewGameState_ShouldReturnTrue()
        {
            Assert.True(target.ShouldReadLineFromConsole);
        }

        [Fact]
        public void Print_ForNewGameState_ShouldAskIfUserWantToPlay()
        {
            StringBuilder result = target.Print();

            Assert.Equal("Do you want to start playing in battleship game? (y or n)", result.ToString());
        }

        [Theory]
        [InlineData("y")]
        [InlineData("Y")]
        public void Process_WhenEnteredDataIsY_ShouldChangeGameStateToRunningGameState(string enteredData)
        {
            IGameState gameState = null;
            gameMock
                .Setup(x => x.TransitionTo(It.IsAny<IGameState>()))
                .Callback<IGameState>((state) => { gameState = state; });

            target.SetGameContext(gameMock.Object);

            target.Process(enteredData);

            gameMock.Verify(x => x.TransitionTo(It.IsAny<IGameState>()));
            Assert.IsType<RunningGameState>(gameState);
            shipCoordinatesGeneratorMock.Verify(x => x.GenerateShips(It.IsAny<byte>(), It.IsAny<IEnumerable<Ship>>()));
        }

        [Theory]
        [InlineData("n")]
        [InlineData("N")]
        [InlineData("a")]
        public void Process_WhenEnteredDataIsNotY_ShouldChangeGameStateToEndedGameState(string enteredData)
        {
            IGameState gameState = null;
            gameMock
                .Setup(x => x.TransitionTo(It.IsAny<IGameState>()))
                .Callback<IGameState>((state) => { gameState = state; });

            target.SetGameContext(gameMock.Object);

            target.Process(enteredData);

            gameMock.Verify(x => x.TransitionTo(It.IsAny<IGameState>()));
            Assert.IsType<EndedGameState>(gameState);
            shipCoordinatesGeneratorMock.Verify(x => x.GenerateShips(It.IsAny<byte>(), It.IsAny<IEnumerable<Ship>>()),
                Times.Never);
        }
    }
}