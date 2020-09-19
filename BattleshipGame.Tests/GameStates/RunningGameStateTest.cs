using System;
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

        public RunningGameStateTest()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock
                .Setup(x => x.GetService(It.IsAny<Type>()))
                .Returns(new EndedGameState(NullLogger<EndedGameState>.Instance));
            
            target = new RunningGameState(serviceProviderMock.Object, NullLogger<RunningGameState>.Instance);
        }

        [Fact]
        public void ShouldReadLineFromConsole_ForRunningGameState_ShouldReturnTrue()
        {
            Assert.True(target.ShouldReadLineFromConsole);
        }
    }
}