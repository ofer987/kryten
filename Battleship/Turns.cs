using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Battleship.Players;

namespace Battleship
{
    public class Turns : IEnumerable<Tuple<Player, Player>>
    {
        public Player PlayerOne { get; }

        public Player PlayerTwo { get; }

        public Turns(Player playerOne, Player playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public IEnumerator<Tuple<Player, Player>> GetEnumerator()
        {
            return InfinitePlayers().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<Tuple<Player, Player>> InfinitePlayers()
        {
            var oddRounds = new Tuple<Player, Player>(PlayerOne, PlayerTwo);
            var evenRounds = new Tuple<Player, Player>(PlayerTwo, PlayerOne);

            while (true)
            {
                yield return oddRounds;
                yield return evenRounds;
            }
        }
    }
}
