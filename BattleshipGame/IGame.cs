using BattleshipGame.GameStates;

namespace BattleshipGame
{
    internal interface IGame
    {
        void TransitionTo(IGameState state);
    }
}