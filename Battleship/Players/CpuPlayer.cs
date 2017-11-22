using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Actions;
using Action = Battleship.Actions.Action;

namespace Battleship.Players
{
    public class CpuPlayer : Player
    {
        public CpuPlayer(Board board) : base(board)
        {
        }

        public override Action Play(Player opponent)
        {
            return new FiringAction(this, opponent, GetRandomCell(opponent.Board));
        }

        private static int GetRandomCell(Board board)
        {
            return new Random().Next(0, board.CellCount);
        }
    }
}
