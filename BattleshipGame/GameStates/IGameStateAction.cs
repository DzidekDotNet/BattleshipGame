using System.Text;

namespace BattleshipGame.GameStates
{
    internal interface IGameStateAction
    {
        StringBuilder Print();
        void Process(string enteredData);
    }
}