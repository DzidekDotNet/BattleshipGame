using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame.Games
{
    internal class ShipRandomCoordinatesGenerator : IShipCoordinatesGenerator
    {
        private readonly IList<Point> coordinatesWithShip = new List<Point>();

        public IList<GeneratedShip> GenerateShips(byte boardSize, IEnumerable<Ship> ships)
        {
            IList<GeneratedShip> generatedShips = new List<GeneratedShip>();

            foreach (Ship ship in ships)
            {
                ShipOrientation shipOrientation = ChooseShipOrientation();
                IList<byte> possibleValues = GetPossibleValuesInAxios(shipOrientation, boardSize, ship.Size);
                byte firstAxiosValue = possibleValues[new Random().Next(possibleValues.Count)];
                byte secondAxiosValue =
                    GetPossibleStartPositionInAxios(shipOrientation, firstAxiosValue, boardSize, ship.Size);
                generatedShips.Add(GetGeneratedShip(shipOrientation, firstAxiosValue, secondAxiosValue, ship));
            }

            return generatedShips;
        }

        private ShipOrientation ChooseShipOrientation()
        {
            var random = new Random().Next(1);
            return random == 0 ? ShipOrientation.Horizontal : ShipOrientation.Vertical;
        }

        private IList<byte> GetPossibleValuesInAxios(ShipOrientation shipOrientation, byte boardSize, byte shipSize)
        {
            IList<byte> possibilities = new List<byte>();
            for (byte i = 0; i < boardSize; i++)
            {
                IList<byte> pointsInLine;
                if (shipOrientation == ShipOrientation.Horizontal)
                {
                    pointsInLine = coordinatesWithShip.Where(p => p.Y == i).OrderBy(p => p.X).Select(p => p.X).ToList();
                }
                else
                {
                    pointsInLine = coordinatesWithShip.Where(p => p.X == i).OrderBy(p => p.Y).Select(p => p.Y).ToList();
                }

                if (!pointsInLine.Any())
                {
                    possibilities.Add(i);
                    continue;
                }
                else
                {
                    if (pointsInLine.First() >= shipSize ||
                        pointsInLine.Last() <= boardSize - 1 - shipSize)
                    {
                        possibilities.Add(i);
                        continue;
                    }
                    else
                    {
                        byte prevValue = pointsInLine.First();
                        for (int j = 1; j < pointsInLine.Count; j++)
                        {
                            if (pointsInLine[j] >= prevValue + shipSize)
                            {
                                possibilities.Add(i);
                                continue;
                            }
                        }
                    }
                }
            }

            return possibilities;
        }

        private byte GetPossibleStartPositionInAxios(ShipOrientation shipOrientation, byte axiosSelected,
            byte boardSize, byte shipSize)
        {
            IList<byte> pointsInLine;
            if (shipOrientation == ShipOrientation.Horizontal)
            {
                pointsInLine = coordinatesWithShip.Where(p => p.X == axiosSelected).OrderBy(p => p.Y).Select(p => p.Y).ToList();
            }
            else
            {
                pointsInLine = coordinatesWithShip.Where(p => p.Y == axiosSelected).OrderBy(p => p.X).Select(p => p.X).ToList();
            }
            
            IList<byte> possibilities = new List<byte>();
            for (byte i = 0; i <= boardSize - shipSize; i++)
            {

                if (!pointsInLine.Any())
                {
                    possibilities.Add(i);
                    continue;
                }
                else
                {
                    if (pointsInLine.First() >= shipSize ||
                        pointsInLine.Last() <= boardSize - 1 - shipSize)
                    {
                        possibilities.Add(i);
                        continue;
                    }
                    else
                    {
                        byte prevValue = pointsInLine.First();
                        for (int j = 1; j < pointsInLine.Count; j++)
                        {
                            if (pointsInLine[j] >= prevValue + shipSize)
                            {
                                possibilities.Add(i);
                                continue;
                            }
                        }
                    }
                }
            }

            if (possibilities.Count == 1)
            {
                return possibilities[0];
            }
            return possibilities[new Random().Next(possibilities.Count-1)];
        }

        private GeneratedShip GetGeneratedShip(ShipOrientation shipOrientation, byte firstAxiosSelected,
            byte secondAxiosStart, Ship ship)
        {
            IList<Point> points = new List<Point>();

            for (byte i = 0; i < ship.Size; i++)
            {
                if (shipOrientation == ShipOrientation.Horizontal)
                {
                    points.Add(new Point(firstAxiosSelected, (byte) (secondAxiosStart + i)));
                }
                else
                {
                    points.Add(new Point((byte) (secondAxiosStart + i), firstAxiosSelected));
                }
            }
            
            return new GeneratedShip(ship, points);
        }
    }
}