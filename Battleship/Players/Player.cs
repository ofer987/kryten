using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Players;
using Battleship.Ships;
using Action = Battleship.Actions.Action;

namespace Battleship.Players
{
    public abstract class Player
    {
        public Board Board { get; }

        public IList<IShip> Ships => Board.Ships;

        protected Player(Board board)
        {
            Board = board;
        }

        public abstract Action Play(Player opponent);
    }
}
