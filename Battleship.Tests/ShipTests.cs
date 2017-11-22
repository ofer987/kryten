using System;
using System.Linq;
using Battleship.Ships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Assert = NUnit.Framework.Assert;

namespace Battleship.Tests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void ShipCreationTests()
        {
            {
                var ship = new Ship(new[] {4, 5, 3});
                Assert.AreEqual(3, ship.Coordinates.Count);
            }

            {
                var ship = new Ship(new[] {3, 5, 3});
                Assert.AreEqual(2, ship.Coordinates.Count);
            }
        }

        [TestMethod]
        public void IsAliveTests()
        {
            // new ship
            var ship = new Ship(new[] {4, 5, 3});
            Assert.IsTrue(ship.IsAlive);

            // Hit once
            ship.Coordinates[0] = false;
            Assert.IsTrue(ship.IsAlive);

            // All hit
            foreach (var cell in ship.Coordinates.Select(coordinate => coordinate.Key).ToArray())
            {
                ship.Coordinates[cell] = false;
            }
            Assert.IsFalse(ship.IsAlive);
        }

        [TestMethod]
        public void SuccessfulHitTests()
        {
            // new ship
            var ship = new Ship(new[] {4, 5, 3});

            Assert.IsTrue(ship.Hit(3));

            var aliveBlocks = ship.Coordinates
                .OrderBy(coordinate => coordinate.Key)
                .Select(coordinate => coordinate.Value)
                .ToArray();
            Assert.AreEqual(new[] {false, true, true}, aliveBlocks);
        }

        [TestMethod]
        public void IsHittableTests()
        {
            // new ship
            var ship = new Ship(new [] {4, 5, 3});

            Assert.IsTrue(ship.IsHittable(3));
            Assert.IsTrue(ship.IsHittable(4));
            Assert.IsTrue(ship.IsHittable(5));
            Assert.IsFalse(ship.IsHittable(-1));
            Assert.IsFalse(ship.IsHittable(6));
        }

        [TestMethod]
        public void FailHitTests()
        {
            // new ship
            var ship = new Ship(new[] {4, 5, 3});

            Assert.IsFalse(ship.Hit(6));
            Assert.IsTrue(ship.IsAlive);
        }
    }
}
