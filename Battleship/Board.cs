using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Battleship.Ships;
using Newtonsoft.Json;

namespace Battleship
{
    public class Board
    {
        private IList<IShip> _ships;

        [JsonIgnore]
        public IList<IShip> Ships
        {
            get
            {
                if (_ships != null)
                {
                    return _ships;
                }

                return BuildShips();
            }
        }

        public int CellCount => Size * Size;

        public int Size { get; set; }

        public int[][] Coordinates { get; set; }

        public Board(int size, int[][] coordinates)
        {
            Size = size;
            Coordinates = coordinates;
        }

        public static Board LoadFromFile(string filepath)
        {
            return JsonConvert.DeserializeObject<Board>(File.ReadAllText(filepath));
        }

        public bool IsHit(int cell)
        {
            var row = cell / Size;
            var column = cell % Size;

            return Coordinates[row][column] != 0;
        }

        private IList<IShip> BuildShips()
        {
            _ships = new List<IShip>();

            foreach (var pair in ParseCoordinates().OrderBy(p => p.Key))
            {
                _ships.Add(new Ship(pair.Value.ToArray()));
            }

            return _ships;
        }

        private IDictionary<int, List<int>> ParseCoordinates()
        {
            var dictionary = new Dictionary<int, List<int>>();

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    var cell = i * Size + j;
                    var number = Coordinates[i][j];

                    if (number != 0)
                    {
                        if (dictionary.TryGetValue(number, out var list))
                        {
                            list.Add(cell);
                        }
                        else
                        {
                            dictionary.Add(number, new List<int> {cell});
                        }
                    }
                }
            }

            return dictionary;
        }
    }
}
