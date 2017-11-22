using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Players;
using Action = Battleship.Actions.Action;

namespace Battleship
{
    public class Game
    {
        public Player PlayerOne { get; }

        public Player PlayerTwo { get; }

        public List<Action> Log { get; }

        public bool IsDone => false;

        public Game(Player playerOne, Player playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            Log = new List<Action>();
        }

        public void Start()
        {
            foreach (var players in new Turns(PlayerOne, PlayerTwo))
            {
                PlayTurn(players.Item1, players.Item2);

                if (IsDone)
                {
                    return;
                }
            }
        }

        public void PlayTurn(Player player, Player opponent)
        {
            var action = player.Play(opponent);

            while (!action.IsDone)
            {
                action.Process();
                Log.Add(action);

                action = action.GetNextAction();
            }
        }
    }
}
