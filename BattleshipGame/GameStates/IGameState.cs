using BattleshipGame.Games;

namespace BattleshipGame.GameStates
{
    internal interface IGameState: IGameStateAction, IGameStateStatus
    {
        IGame Game { get; }
        
        void SetGameContext(IGame game);
        
    }
}