using Battleship.Players;

namespace Battleship.Actions
{
    public abstract class Action
    {
        public Player Player { get; }

        public virtual bool IsDone => false;

        protected Action(Player player)
        {
            Player = player;
        }

        public virtual void Process()
        {
        }

        public abstract Action GetNextAction();
    }
}
