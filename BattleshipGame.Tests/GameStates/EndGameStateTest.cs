using BattleshipGame.GameStates;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.GameStates
{
    [UnitTest]
    public class EndGameStateTest
    {
        private readonly EndGameState target;
        public EndGameStateTest()
        {
            target = new EndGameState();
        }
        
        [Fact]
        public void ShouldReadLineFromConsole_ForEndGameState_ShouldReturnTrue()
        {
            Assert.True(target.ShouldReadLineFromConsole);
        }
    }
}