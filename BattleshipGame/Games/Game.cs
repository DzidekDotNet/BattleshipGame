using System.Collections.Generic;
using System.Text;
using BattleshipGame.GameStates;
using Microsoft.Extensions.Logging;

namespace BattleshipGame.Games
{
    internal class Game : IGame, IGameStateAction, IGameStateStatus
    {
        public bool ShouldReadLineFromConsole => State.ShouldReadLineFromConsole;
        private readonly ILogger<Game> logger;
        private IGameState State { get; set; }
        public IGameBoard Board { get; }
        public IEnumerable<Ship> ShipsToGenerate => new List<Ship>
        {
            new Battleship(),
            new Destroyer(),
            new Destroyer()
        };

        internal Game(IGameState initialState, IGameBoard gameBoard, ILogger<Game> logger)
        {
            this.logger = logger;
            Board = gameBoard;
            TransitionTo(initialState);
        }

        public void SetGeneratedShips(IList<GeneratedShip> generatedShips)
        {
            ((List<GeneratedShip>)Board.GeneratedShips).AddRange(generatedShips);
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

        public StringBuilder Process(string enteredData)
        {
            return State.Process(enteredData);
        }
    }
}