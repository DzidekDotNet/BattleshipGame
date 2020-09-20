using System.Collections.Generic;

namespace BattleshipGame.Games
{
    internal interface IShipCoordinatesGenerator
    {
        IList<GeneratedShip> GenerateShips(byte boardSize, IEnumerable<Ship> ships);
    }
}