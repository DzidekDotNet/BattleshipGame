using BattleshipGame.GameStates;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.GameStates
{
    [UnitTest]
    public class RunningGameStateTest
    {
        private readonly RunningGameState target;

        public RunningGameStateTest()
        {
            target = new RunningGameState();
        }

        [Fact]
        public void ShouldReadLineFromConsole_ForRunningGameState_ShouldReturnTrue()
        {
            Assert.True(target.ShouldReadLineFromConsole);
        }
    }
}