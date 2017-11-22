using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Actions;

using Action = Battleship.Actions.Action;

namespace Battleship.Players
{
    public class HumanPlayer : Player
    {
        public string Name { get; }

        public HumanPlayer(Board board) : base(board)
        {
        }

        public override Action Play(Player opponent)
        {
            throw new NotImplementedException();
        }
    }
}
