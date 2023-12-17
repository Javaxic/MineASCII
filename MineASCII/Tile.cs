using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineASCII
{
    internal class Tile
    {
        public string Name;
        public string Sprite;
        public ConsoleColor Color;
        public bool isPassable;

        public Tile(string name, string sprite, ConsoleColor color, bool isPassable = false)
        {
            Name = name;
            Sprite = sprite;
            Color = color;
            this.isPassable = isPassable;
        }
    }
}
