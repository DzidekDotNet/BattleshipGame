using System.Text;
using BattleshipGame.GameStates;
using Moq;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.GameStates
{
    [UnitTest]
    public class EndedGameStateTest
    {
        private readonly EndedGameState target;
        private readonly Mock<IGame> gameMock;
        public EndedGameStateTest()
        {
            gameMock = new Mock<IGame>();
            
            target = new EndedGameState();
        }
        
        [Fact]
        public void ShouldReadLineFromConsole_ForEndedGameState_ShouldReturnFalse()
        {
            Assert.False(target.ShouldReadLineFromConsole);
        }
        
        [Fact]
        public void Print_ForEndedGameState_ShouldReturnEmpty()
        {
            StringBuilder result = target.Print();

            Assert.Equal("", result.ToString());
        }
        
        [Fact]
        public void Process_ForEndedGameState_ShouldNotSetNewState()
        {
            gameMock
                .Setup(x => x.TransitionTo(It.IsAny<IGameState>()));
            
            target.SetGameContext(gameMock.Object);

            target.Process(It.IsAny<string>());

            gameMock.Verify(x => x.TransitionTo(It.IsAny<IGameState>()), Times.Never);
        }
    }
}