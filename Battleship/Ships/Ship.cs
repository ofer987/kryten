using System.Collections.Generic;
using System.Linq;

namespace Battleship.Ships
{
    public class Ship : IShip
    {
        public Dictionary<int, bool> Coordinates { get; }

        public bool IsAlive => Coordinates.Any(coord => coord.Value);

        public bool IsNull => false;

        public Ship(IEnumerable<int> coordinates)
        {
            Coordinates = new Dictionary<int, bool>();
            foreach (var coordinate in coordinates.Distinct())
            {
                Coordinates.Add(coordinate, true);
            }
        }

        public bool IsHittable(int cell)
        {
            return Coordinates.ContainsKey(cell);
        }

        public bool Hit(int cell)
        {
            if (IsHittable(cell))
            {
                Coordinates[cell] = false;

                return true;
            }

            return false;
        }
    }
}
