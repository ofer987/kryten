using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Ships
{
    public interface IShip
    {
        bool IsNull { get; }

        bool IsHittable(int cell);

        bool Hit(int cell);
    }
}
