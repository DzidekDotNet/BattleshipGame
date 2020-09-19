namespace BattleshipGame.GameStates
{
    internal interface IGameState: IGameStateAction, IGameStateStatus
    {
        
        
        void SetGameContext(IGame game);
        
    }
}