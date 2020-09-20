using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Games;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.Games
{
    [UnitTest]
    public class ShipRandomCoordinatesGeneratorTest
    {
        private readonly ShipRandomCoordinatesGenerator target;

        public ShipRandomCoordinatesGeneratorTest()
        {
            target = new ShipRandomCoordinatesGenerator();
        }

        [Fact]
        public void GenerateShips_ForOneShip_ReturnsGeneratedCoordinatesForOneShip()
        {
            IList<GeneratedShip> result = target.GenerateShips(5, new List<Ship>() {new Battleship()});
            
            Assert.Single(result);
            Assert.IsType<Battleship>(result[0].Ship);
            Assert.Equal(new Battleship().Size, result[0].Points.Count);
        } 
        
        [Fact]
        public void GenerateShips_ForTwoShip_ReturnsGeneratedCoordinatesForTwoShipAndShouldHaveDifferentCoordinates()
        {
            IList<GeneratedShip> result = target.GenerateShips(5, new List<Ship>() {new Battleship(), new Destroyer()});
            
            Assert.Equal(2, result.Count);
            Assert.Empty(result[0].Points.Intersect(result[1].Points));
        }
        
        [Fact]
        public void GenerateShips_ForOneShipAndSmallBoard_ReturnsCoordinatesInBoard()
        {
            IList<GeneratedShip> result = target.GenerateShips(2, new List<Ship>() {new Ship(2)});
            
            Assert.Equal(1, result.Count);
            Assert.Empty(result[0].Points.Where(p => p.X > 1 || p.Y > 1));
        }
    }
}