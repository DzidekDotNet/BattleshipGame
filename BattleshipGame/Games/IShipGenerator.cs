using System.Collections.Generic;

namespace BattleshipGame.Games
{
    internal interface IShipGenerator
    {
        IList<GeneratedShip> GenerateShips(byte boardSize, IEnumerable<Ship> ships);
    }
}