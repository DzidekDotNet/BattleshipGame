using System.Collections.Generic;

namespace BattleshipGame.Games
{
    internal interface IShootChecker
    {
        ShootResult CheckShot(Point point, IList<GeneratedShip> generatedShips, IList<Point> shoots);
    }
}