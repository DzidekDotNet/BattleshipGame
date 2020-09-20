using System.Collections.Generic;

namespace BattleshipGame.Games
{
    internal class GameBoard: IGameBoard
    {
        public byte Size => 10;
        public IList<GeneratedShip> GeneratedShips { get; } = new List<GeneratedShip>();
        public IList<Point> Shoots { get; } = new List<Point>();
    }
}