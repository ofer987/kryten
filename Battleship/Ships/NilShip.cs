using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Ships
{
    public class NilShip : IShip
    {
        public bool IsNull => true;

        public bool IsHittable(int cell)
        {
            return false;
        }

        public bool Hit(int cell)
        {
            return false;
        }
    }
}
