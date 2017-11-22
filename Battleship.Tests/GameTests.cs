using System;
using Battleship.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Assert = NUnit.Framework.Assert;

namespace Battleship.Tests
{
    [TestClass]
    public class GameTests
    {
        private static int BoardSize => 4;

        private static Player Oren
        {
            get
            {
                var coordinates = new[]
                {
                    new[] {1, 0, 0, 0},
                    new[] {1, 0, 2, 0},
                    new[] {1, 0, 2, 0},
                    new[] {3, 3, 2, 0}
                };

                var board = new Board(BoardSize, coordinates);

                return new CpuPlayer(board);
            }
        }

        private static Player Alan
        {
            get
            {
                var coordinates = new[]
                {
                    new[] {0, 1, 1, 0},
                    new[] {0, 2, 2, 0},
                    new[] {0, 3, 3, 5},
                    new[] {0, 4, 4, 5}
                };

                var board = new Board(BoardSize, coordinates);

                return new CpuPlayer(board);
            }
        }

        private static Game Game => new Game(Oren, Alan);

        [TestMethod]
        public void TestPlayTurn()
        {
            var game = Game;

            game.PlayTurn(game.PlayerOne, game.PlayerTwo);
        }
    }
}
