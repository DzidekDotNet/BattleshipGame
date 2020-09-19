namespace BattleshipGame.Games
{
    internal class Point
    {
        public byte X { get; }
        public byte Y { get; }

        internal Point(byte x, byte y)
        {
            X = x;
            Y = y;
        }
    }
}