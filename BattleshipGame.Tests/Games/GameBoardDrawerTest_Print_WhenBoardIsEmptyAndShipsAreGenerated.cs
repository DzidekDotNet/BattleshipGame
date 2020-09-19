using System.Collections;
using System.Collections.Generic;
using BattleshipGame.Games;

namespace BattleshipGame.Tests.Games
{
    public class GameBoardDrawerTest_Print_WhenBoardIsEmptyAndShipsAreGenerated : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                2,
                new List<GeneratedShip>()
                {
                    new GeneratedShip(new Battleship(), new List<Point>(){new Point(1,1)})
                },
                ""
            };
            yield return new object[]
            {
                5,
                new List<GeneratedShip>()
                {
                    new GeneratedShip(new Battleship(), new List<Point>(){new Point(1,1)}),
                    new GeneratedShip(new Battleship(), new List<Point>(){new Point(4,4)})
                },
                ""
            };
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}