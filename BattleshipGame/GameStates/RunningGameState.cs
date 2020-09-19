using System.Text;

namespace BattleshipGame.GameStates
{
    internal class RunningGameState: BaseGameState
    {
        public override bool ShouldReadLineFromConsole => true;
        public override StringBuilder Print()
        {
            throw new System.NotImplementedException();
        }

        public override void Process(string enteredData)
        {
            throw new System.NotImplementedException();
        }
    }
}