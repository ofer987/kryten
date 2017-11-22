using System;
using Battleship.Actions;
using Battleship.Players;
using Battleship.Ships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using Assert = NUnit.Framework.Assert;

namespace Battleship.Tests
{
    [TestClass]
    public class HitActionTests
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

        [TestMethod]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(10)]
        public void IsHittableTest(int cell)
        {
            var action = new HitAction(Alan, Oren, cell);

            Assert.IsFalse(action.OpponentShip.IsNull);
        }

        [TestMethod]
        [TestCase(5)]
        [TestCase(-10)]
        [TestCase(15)]
        public void IsNotHittableTest(int cell)
        {
            var action = new HitAction(Alan, Oren, cell);

            Assert.IsTrue(action.OpponentShip.IsNull);
        }
    }
}
