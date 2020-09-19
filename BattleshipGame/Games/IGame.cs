using System.Collections.Generic;
using BattleshipGame.GameStates;

namespace BattleshipGame.Games
{
    internal interface IGame
    {
        void TransitionTo(IGameState state);
        
        IGameBoard Board { get; }
        
        IEnumerable<Ship> ShipsToGenerate { get; }

        void SetGeneratedShips(IList<GeneratedShip> generatedShips);
    }
}