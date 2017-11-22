using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using Assert = NUnit.Framework.Assert;

namespace Battleship.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        [TestCase("file_exists.json", 4, 3)]
        public void LoadFromFileTest(string filepath, int boardSize, int shipCount)
        {
            var path = Path.Combine(GetAssemblyPath(), filepath);
            Assert.DoesNotThrow(() => Board.LoadFromFile(path));

            var board = Board.LoadFromFile(path);
            Assert.IsNotNull(board);
            Assert.AreEqual(shipCount, board.Ships.Count);
            Assert.AreEqual(boardSize, board.Size);
        }

        [TestMethod]
        [TestCase("void_file.json")]
        public void FailsToLoadFromFileTest(string filepath)
        {
            var path = Path.Combine(GetAssemblyPath(), filepath);
            Assert.Throws<FileNotFoundException>(() => Board.LoadFromFile(path));
        }

        [TestMethod]
        public void IsHitTests()
        {
            var coordinates = new[]
            {
                new[] {0, 1, 1, 0},
                new[] {0, 2, 2, 0},
                new[] {0, 3, 3, 5},
                new[] {0, 4, 4, 5}
            };

            var board = new Board(4, coordinates);

            Assert.IsFalse(board.IsHit(0));
            Assert.IsTrue(board.IsHit(1));
            Assert.IsTrue(board.IsHit(13));
            Assert.IsTrue(board.IsHit(14));
            Assert.IsTrue(board.IsHit(15));
            Assert.Throws<IndexOutOfRangeException>(() => board.IsHit(-1));
            Assert.Throws<IndexOutOfRangeException>(() => board.IsHit(16));
        }

        private static string GetAssemblyPath()
        {
            var assembly = System.Reflection.Assembly
                .GetExecutingAssembly()
                .GetName()
                .CodeBase;
            var path = Path.GetDirectoryName(assembly) ?? "";

            return Regex.Replace(path, "file:\\\\", "");
        }
    }
}
