using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleship.Players;
using Battleship.Ships;

namespace Battleship.Actions
{
    public class HitAction : Action
    {
        public Player Opponent { get; }

        public int OpponentCell { get; }

        public IShip OpponentShip => Opponent
            .Ships
            .Where(ship => ship.IsHittable(OpponentCell))
            .DefaultIfEmpty(new NilShip())
            .FirstOrDefault();

        public HitAction(Player player, Player opponent, int opponentCell) : base(player)
        {
            Opponent = opponent;
            OpponentCell = opponentCell;
        }

        public override void Process()
        {
            OpponentShip.Hit(OpponentCell);
        }

        public override Action GetNextAction()
        {
            return new NilAction();
        }
    }
}
