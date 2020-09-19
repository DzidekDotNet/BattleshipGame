using System.Text;

namespace BattleshipGame.Games
{
    internal interface IGameBoardDrawer
    {
        StringBuilder PrintBoard(IGameBoard board);
    }
}