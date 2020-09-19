namespace BattleshipGame.GameStates
{
    public interface IGameStateStatus
    {
        bool ShouldReadLineFromConsole { get; }
    }
}