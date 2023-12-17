using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineASCII
{
    internal class Player
    {
        public static string Sprite = "☻";
        public static ConsoleColor colorSprite = ConsoleColor.Green;

        public static int positionX = 30;
        public static int positionY = 30;

        public static void Move()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D:
                    if (Collision(1, 0))
                    {
                        Console.SetCursorPosition(positionX, positionY);
                        Console.Write(" ");
                        positionX += 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (Collision(-1, 0))
                    {
                        Console.SetCursorPosition(positionX, positionY);
                        Console.Write(" ");
                        positionX -= 1;
                    }
                    break;
                case ConsoleKey.W:
                    if (Collision(0, -1))
                    {
                        Console.SetCursorPosition(positionX, positionY);
                        Console.Write(" ");
                        positionY -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (Collision(0, 1))
                    {
                        Console.SetCursorPosition(positionX, positionY);
                        Console.Write(" ");
                        positionY += 1;
                    }
                    break;
            }

            CameraMove(6);
            Mining(key);

            Console.ForegroundColor = colorSprite;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(Sprite);
        }

        public static void CameraMove(int renderDistance)
        {
            if (positionX + 7 < Game.World.WIDTH)
            {
                for (int y = Player.positionY - renderDistance; y < Player.positionY + renderDistance; y++)
                {
                    for (int x = Player.positionX - (renderDistance + 4); x < Player.positionX + (renderDistance + 4); x++)
                    {
                        if (Game.World.GetTile(x, y) != null)
                        {
                            Console.ForegroundColor = Game.World.GetTile(x, y).Color;
                            Console.SetCursorPosition(x, y);
                            Console.Write(Game.World.GetTile(x, y).Sprite);
                        }
                        else
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            
        }

        public static bool Collision(int directX, int directY)
        {
            if (positionX + 7 < Game.World.WIDTH)
            {
                if (Game.World.GetTile(positionX + directX, positionY + directY) == null || Game.World.GetTile(positionX + directX, positionY + directY).isPassable == true)
                    return true;
            }
            return false;
        }

        public static void Mining(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(positionX + 1, positionY);
                    Game.World.SetTile(null, positionX + 1, positionY);
                    Console.Write(" ");
                    break;
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(positionX - 1, positionY);
                    Game.World.SetTile(null, positionX - 1, positionY);
                    Console.Write(" ");
                    break;
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(positionX, positionY - 1);
                    Game.World.SetTile(null, positionX, positionY - 1);
                    Console.Write(" ");
                    break;
                case ConsoleKey.DownArrow:
                    Console.SetCursorPosition(positionX, positionY + 1);
                    Game.World.SetTile(null, positionX, positionY + 1);
                    Console.Write(" ");
                    break;
            }
        }
    }
}
