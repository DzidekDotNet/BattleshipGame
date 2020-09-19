using System.Text;
using BattleshipGame.GameStates;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.GameStates
{
    [UnitTest]
    public class EndGameStateTest
    {
        private readonly EndGameState target;
        private readonly Mock<IGame> gameMock;
        public EndGameStateTest()
        {
            gameMock = new Mock<IGame>();
            
            target = new EndGameState(new NullLoggerFactory());
        }
        
        [Fact]
        public void ShouldReadLineFromConsole_ForEndGameState_ShouldReturnTrue()
        {
            Assert.True(target.ShouldReadLineFromConsole);
        }
        
        [Fact]
        public void Print_ForEndGameState_ShouldSendCongratulations()
        {
            StringBuilder result = target.Print();

            Assert.Equal("You win, you are awesome. Press any key to end.", result.ToString());
        }
        
        [Fact]
        public void Process_ForEndedGameState_ShouldNotSetNewState()
        {
            IGameState gameState = null;
            gameMock
                .Setup(x => x.TransitionTo(It.IsAny<IGameState>()))
                .Callback<IGameState>((state) => { gameState = state; });
            
            target.SetGameContext(gameMock.Object);

            target.Process(It.IsAny<string>());

            gameMock.Verify(x => x.TransitionTo(It.IsAny<IGameState>()));
            Assert.IsType<EndedGameState>(gameState);
        }
    }
}