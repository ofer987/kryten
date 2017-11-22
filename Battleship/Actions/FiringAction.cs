using Battleship.Players;

namespace Battleship.Actions
{
    public class FiringAction : Action
    {
        public Player Opponent { get; }

        public bool IsHit => Opponent.Board.IsHit(OpponentCell);

        public int OpponentCell { get; }

        public FiringAction(Player player, Player opponent, int opponentCell) : base(player)
        {
            Opponent = opponent;
            OpponentCell = opponentCell;
        }

        public override Action GetNextAction()
        {
            if (IsHit)
            {
                return new HitAction(Player, Opponent, OpponentCell);
            }

            return new NilAction();
        }
    }
}
