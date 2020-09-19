using System;
using System.Text;

namespace BattleshipGame.GameStates
{
    internal class NewGameState : BaseGameState
    {
        public override bool ShouldReadLineFromConsole => true;

        public override StringBuilder Print()
        {
            throw new NotImplementedException();
        }

        public override void Process(string enteredData)
        {
            throw new NotImplementedException();
        }
    }
}