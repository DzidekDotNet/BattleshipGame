using System;
using System.Text;

namespace BattleshipGame.GameStates
{
    internal class NewGameState : IGameState
    {
        public bool ShouldReadLineFromConsole => true;

        public StringBuilder Print()
        {
            throw new NotImplementedException();
        }

        public void Process(string enteredData)
        {
            throw new NotImplementedException();
        }

        public void SetGameContext(IGame game)
        {
            throw new NotImplementedException();
        }
    }
}