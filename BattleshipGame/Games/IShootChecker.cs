namespace BattleshipGame.Games
{
    internal interface IShootChecker
    {
        ShootResult CheckShot(Point point, IGameBoard gameBoard);
    }
}