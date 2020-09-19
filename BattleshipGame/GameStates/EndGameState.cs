using System.Text;

namespace BattleshipGame.GameStates
{
    internal class EndGameState :IGameState
    {
        public IGame Game { get; }
        public bool ShouldReadLineFromConsole => true;
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