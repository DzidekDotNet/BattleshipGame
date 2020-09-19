using System.Text;

namespace BattleshipGame.GameStates
{
    internal class EndedGameState:IGameState
    {
        public bool ShouldReadLineFromConsole => false;
        public StringBuilder Print()
        {
            throw new System.NotImplementedException();
        }

        public void Process(string enteredData)
        {
            throw new System.NotImplementedException();
        }

        public void SetGameContext(IGame game)
        {
            throw new System.NotImplementedException();
        }
    }
}