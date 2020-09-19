using BattleshipGame.GameStates;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.GameStates
{
    [UnitTest]
    public class NewGameStateTest
    {
        private readonly NewGameState target;
        public NewGameStateTest()
        {
            target = new NewGameState();
        }
        
        [Fact]
        public void ShouldReadLineFromConsole_ForNewGameState_ShouldReturnTrue()
        {
            Assert.True(target.ShouldReadLineFromConsole);
        }
    }
}