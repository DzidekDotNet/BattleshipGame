using System.Text;

namespace BattleshipGame.GameStates
{
    internal abstract class BaseGameState : IGameState
    {
        public abstract bool ShouldReadLineFromConsole { get; }
        public IGame Game { get; private set; }
        public abstract StringBuilder Print();
        public abstract void Process(string enteredData);

        public void SetGameContext(IGame game)
        {
            Game = game;
        }
    }
}