using BattleshipGame.GameStates;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.GameStates
{
    [UnitTest]
    public class EndedGameStateTest
    {
        private readonly EndedGameState target;
        public EndedGameStateTest()
        {
            target = new EndedGameState();
        }
        
        [Fact]
        public void ShouldReadLineFromConsole_ForEndedGameState_ShouldReturnFalse()
        {
            Assert.False(target.ShouldReadLineFromConsole);
        }
    }
}