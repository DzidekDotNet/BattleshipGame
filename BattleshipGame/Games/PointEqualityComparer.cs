using System.Collections.Generic;

namespace BattleshipGame.Games
{
    internal class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point item1, Point item2)
        {
            if (item1 == null && item2 == null)
                return true;
            else if ((item1 != null && item2 == null) ||
                     (item1 == null && item2 != null))
                return false;

            return item1.X.Equals(item2.X) &&
                   item1.Y.Equals(item2.Y);
        }

        public int GetHashCode(Point item)
        {
            return new {item.X, item.Y}.GetHashCode();
        }
    }
}