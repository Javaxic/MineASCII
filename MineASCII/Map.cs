using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MineASCII
{
    internal class Map
    {
        public  int WIDTH = 100;
        public  int HEIGHT = 50;

        public Tile[,] Gird;

        public Map()
        {
            Gird = new Tile[HEIGHT, WIDTH];
        }

        public void RenderFull()
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++) 
                {
                    if (Gird[y, x] != null)
                    {
                        Console.ForegroundColor = Gird[y, x].Color;
                        Console.SetCursorPosition(x, y);
                        Console.Write(Gird[y, x].Sprite);
                    }
                }
                Console.WriteLine();
            }
        }

        public void SetTile(Tile tile, int x, int y)
        {
            Gird[y, x] = tile;
        }

        public Tile GetTile(int x, int y)
        {
            return Gird[y, x];
        }

        public void SetFillRectangle(Tile tile, int width, int height, int x, int y)
        {
            for (int y1 = 0; y1 < height; y1++)
            {
                for (int x1 = 0; x1 < width; x1++)
                {
                    Gird[y1 + y, x1 + x] = tile;
                }
            }
        }
    }
}
