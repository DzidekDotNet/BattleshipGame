using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame.Games
{
    internal class ShootChecker : IShootChecker
    {
        private List<Point> shipCoordinates;

        public ShootResult CheckShot(Point point, IList<GeneratedShip> generatedShips, IList<Point> shoots)
        {
            Point shoot = shoots.FirstOrDefault(p => p.X == point.X && p.Y == point.Y);
            if (shoot != null)
            {
                if (GetAllShipsCoordinates(generatedShips).Any(p => p.X == point.X && p.Y == point.Y))
                {
                    if (GetAllShipsCoordinates(generatedShips).Intersect(shoots, new PointEqualityComparer()).Count() ==
                        GetAllShipsCoordinates(generatedShips).Count)
                    {
                        return ShootResult.SinkAllShips;
                    }

                    IList<Point> hitShipPoints = generatedShips.First(generatedShip =>
                        generatedShip.Points.Any(shipPoint => shipPoint.X == point.X && shipPoint.Y == point.Y)).Points;
                    if (hitShipPoints.Intersect(shoots, new PointEqualityComparer()).Count() ==
                        hitShipPoints.Count)
                    {
                        return ShootResult.HitAndSink;
                    }
                    return ShootResult.Hit;
                }
                else
                {
                    return ShootResult.Miss;
                }
            }

            return ShootResult.WrongShoot;
        }

        private IList<Point> GetAllShipsCoordinates(IList<GeneratedShip> generatedShips)
        {
            if (shipCoordinates == null)
            {
                shipCoordinates = new List<Point>();
                foreach (GeneratedShip ship in generatedShips)
                {
                    shipCoordinates.AddRange(ship.Points);
                }
            }

            return shipCoordinates;
        }
    }
}