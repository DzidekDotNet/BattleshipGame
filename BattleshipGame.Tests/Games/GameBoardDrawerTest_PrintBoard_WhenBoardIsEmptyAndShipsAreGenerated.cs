using System.Collections;
using System.Collections.Generic;
using BattleshipGame.Games;

namespace BattleshipGame.Tests.Games
{
    public class GameBoardDrawerTest_PrintBoard_WhenBoardIsEmptyAndShipsAreGenerated : IEnumerable<object[]>
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
                @"   | A | B |
------------
 1 |   |   |
------------
 2 |   |   |
------------
"
            };
            yield return new object[]
            {
                3,
                new List<GeneratedShip>()
                {
                    new GeneratedShip(new Battleship(), new List<Point>(){new Point(1,1)}),
                    new GeneratedShip(new Battleship(), new List<Point>(){new Point(2,2)})
                },
                @"   | A | B | C |
----------------
 1 |   |   |   |
----------------
 2 |   |   |   |
----------------
 3 |   |   |   |
----------------
"
            };
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}