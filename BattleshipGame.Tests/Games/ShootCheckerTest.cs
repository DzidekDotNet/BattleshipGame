using System.Collections.Generic;
using BattleshipGame.Games;
using Xunit;
using Xunit.Categories;

namespace BattleshipGame.Tests.Games
{
    [UnitTest]
    public class ShootCheckerTest
    {
        private readonly ShootChecker target;
        private readonly IList<GeneratedShip> generatedShips;

        public ShootCheckerTest()
        {
            generatedShips = new List<GeneratedShip>()
            {
                new GeneratedShip(new Ship(2), new List<Point>()
                {
                    new Point(0, 0),
                    new Point(0, 1)
                }),
                new GeneratedShip(new Ship(2), new List<Point>()
                {
                    new Point(1, 0),
                    new Point(1, 1)
                })
            };
            target = new ShootChecker();
        }

        [Fact]
        public void CheckShot_WhenHit_ReturnsHitResult()
        {
            Point point = new Point(1, 1);

            ShootResult result = target.CheckShot(point, generatedShips, new List<Point>() {new Point(1, 1)});

            Assert.Equal(ShootResult.Hit, result);
        }

        [Fact]
        public void CheckShot_WhenMiss_ReturnsMissResult()
        {
            Point point = new Point(2, 2);

            ShootResult result = target.CheckShot(point, generatedShips, new List<Point>() {new Point(2, 2)});

            Assert.Equal(ShootResult.Miss, result);
        }

        [Fact]
        public void CheckShot_WhenHitAndSink_ReturnsHitAndSinkResult()
        {
            Point point = new Point(1, 1);

            ShootResult result = target.CheckShot(point, generatedShips,
                new List<Point>() {new Point(1, 0), new Point(1, 1)});

            Assert.Equal(ShootResult.HitAndSink, result);
        }

        [Fact]
        public void CheckShot_WhenSinkAllShips_ReturnsSinkAllShipsResult()
        {
            Point point = new Point(1, 1);

            ShootResult result = target.CheckShot(point, generatedShips,
                new List<Point>()
                {
                    new Point(0, 0),
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(1,1)
                });

            Assert.Equal(ShootResult.SinkAllShips, result);
        }
    }
}