using System;
using System.Text;

namespace BattleshipGame.GameStates
{
    internal class EndedGameState : BaseGameState
    {
        public override bool ShouldReadLineFromConsole => false;

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