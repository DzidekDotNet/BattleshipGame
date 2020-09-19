using System.Collections.Generic;

namespace BattleshipGame.Games
{
    internal class GeneratedShip
    {
        internal Ship Ship { get; }
        internal IList<Point> Points { get; }

        internal GeneratedShip(Ship ship, IList<Point> points)
        {
            Ship = ship;
            Points = points;
        }
    }
}