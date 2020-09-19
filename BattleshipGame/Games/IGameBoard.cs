using System.Collections.Generic;

namespace BattleshipGame.Games
{
    internal interface IGameBoard
    {
        byte Size { get; }
        
        IList<GeneratedShip> GeneratedShips { get; }
        
        IList<Point> Shoots { get; }
    }
}