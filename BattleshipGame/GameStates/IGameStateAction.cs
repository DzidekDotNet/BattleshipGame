using System.Text;

namespace BattleshipGame.GameStates
{
    internal interface IGameStateAction
    {
        StringBuilder Print();
        StringBuilder Process(string enteredData);
    }
}