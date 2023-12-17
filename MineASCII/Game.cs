using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MineASCII
{
    internal class Game
    {
        public static Random rnd = new Random();
        public static Map World = new Map();

        public static Tile wall = new Tile("wall", "@", ConsoleColor.Gray);
        public static Tile stone = new Tile("stone", "#", ConsoleColor.DarkGray);

        public static Tile emerald = new Tile("emerald", "$", ConsoleColor.DarkGreen);

        public static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;

            MineGeneration();
            Console.SetCursorPosition(Player.positionX, Player.positionY);
            Console.ForegroundColor = Player.colorSprite;
            Console.Write(Player.Sprite);

            while (true)
            {
                Player.Move();
                Console.SetCursorPosition(102, 5);
                Console.WriteLine("X: " + Player.positionX + " " + "Y: " + Player.positionY);
            }
        }

        public static void MineGeneration()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int y = 0; y < World.HEIGHT; y++)
            {
                for (int x = 0; x < World.WIDTH; x++)
                {
                    Console.Write("█");
                }
                Console.WriteLine();
            }

            for (int y = 0; y < World.HEIGHT; y++)
            {
                for (int x  = 0; x < World.WIDTH; x++)
                {
                    if (rnd.Next(0, 23) == 0)
                        World.SetTile(wall, x, y);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int y = 1; y < World.HEIGHT - 1; y++)
                {
                    for (int x = 1; x < World.WIDTH - 1; x++)
                    {
                        if (World.GetTile(x, y) != null && World.GetTile(x, y) == wall)
                        {
                            World.SetTile(wall, x, y);
                            switch (rnd.Next(1, 5))
                            {
                                case 1:
                                    World.SetTile(wall, x - 1, y);
                                    break;
                                case 2:
                                    World.SetTile(wall, x + 1, y);
                                    break;
                                case 3:
                                    World.SetTile(wall, x, y + 1);
                                    break;
                                case 4:
                                    World.SetTile(wall, x, y - 1);
                                break;
                            }
                        }
                    }
                }
            }

            for (int y = 1; y < World.HEIGHT - 1; y++)
            {
                for (int x = 1; x < World.WIDTH - 1; x++)
                {
                    int res = rnd.Next(0, 5);

                    if (World.GetTile(x, y) != null && World.GetTile(x, y) == wall && res == 0)
                        World.SetTile(stone, x, y);
                }
            }

            for (int y = 0; y < World.HEIGHT; y++)
            {
                for (int x = 0; x < World.WIDTH; x++)
                {
                    if (World.GetTile(x, y) == stone && rnd.Next(0, 50) == 0)
                        World.SetTile(emerald, x, y);
                }
            }
        }
    }
}
