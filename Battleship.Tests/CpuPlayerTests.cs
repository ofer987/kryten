using System;
using Battleship.Actions;
using Battleship.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Battleship.Tests
{
    [TestClass]
    public class CpuPlayerTests
    {
        [SetUp]
        public void SetUp()
        {
        }

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
        public void PlayMyTurnTest()
        {
            var action = Game.PlayerOne.Play(Game.PlayerTwo);

            Assert.AreEqual(typeof(FiringAction), action.GetType());

            Assert.GreaterOrEqual(((FiringAction) action).OpponentCell, 0);
            Assert.LessOrEqual(((FiringAction) action).OpponentCell, Game.PlayerOne.Board.CellCount);
        }
    }
}
