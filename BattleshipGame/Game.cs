using System.Text;
using BattleshipGame.GameStates;
using Microsoft.Extensions.Logging;

namespace BattleshipGame
{
    internal class Game : IGame, IGameStateAction, IGameStateStatus
    {
        public bool ShouldReadLineFromConsole => State.ShouldReadLineFromConsole;
        private readonly ILogger<Game> logger;
        private IGameState State { get; set; }

        internal Game(IGameState initialState, ILogger<Game> logger)
        {
            this.logger = logger;
            TransitionTo(initialState);
        }

        public void TransitionTo(IGameState state)
        {
            logger.LogTrace($"Setting game state {state.GetType().Name}.");
            State = state;
            State.SetGameContext(this);
        }

        public StringBuilder Print()
        {
            return State.Print();
        }

        public void Process(string enteredData)
        {
            State.Process(enteredData);
        }
    }
}