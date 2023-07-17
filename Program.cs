using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program230717
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] map = {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                    {0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0},
                    {0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0},
                    {0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
                    {0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 2, 0, 0, 1, 0},
                    {0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                    {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                };

            int playerX = 2;
            int playerY = 2;
            int monsterX = 10;
            int monsterY = 10;
            int count = 0;

            while (true)
            {
                if (map[playerY, playerX] == 2)
                {
                    Console.WriteLine("클리어");
                    break;
                }
                if (playerX == monsterX && playerY == monsterY)
                {
                    Console.WriteLine("게임오버");
                    break;
                }
                ConsoleKeyInfo info = Console.ReadKey(true);

                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (map[playerY, playerX - 1] != 1) playerX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[playerY, playerX + 1] != 1) playerX++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (map[playerY - 1, playerX] != 1) playerY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[playerY + 1, playerX] != 1) playerY++;
                        break;
                }
                count++;

                if (count >= 2)
                {
                    count = 0;
                    if (playerX > monsterX && map[monsterY, monsterX + 1] != 1) monsterX++;
                    else if (playerX < monsterX && map[monsterY, monsterX - 1] != 1) monsterX--;
                    else count++;

                    if (playerY > monsterY && map[monsterY + 1, monsterX] != 1) monsterY++;
                    else if (playerY < monsterY && map[monsterY - 1, monsterX] != 1) monsterY--;
                    else count++;

                    if (count >= 2)
                    {
                        if (map[monsterY + 1, monsterX] == 1) monsterY--;
                        else monsterY++;
                        if (map[monsterY, monsterX + 1] == 1) monsterX--;
                        else monsterX++;
                    }
                }

                Console.Clear();
                Console.WriteLine("X를 찾아라");
                //for (int y = playerY - 2; y <= playerY + 2; y++)
                //{
                //    for (int x = playerX - 2; x <= playerX + 2; x++)
                //    {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        if (monsterX == x && monsterY == y)
                        {
                            Console.Write("ㅁ");
                        }
                        else if (playerX == x && playerY == y)
                        {
                            Console.Write("ㅇ");
                        }
                        else if (map[y, x] == 0)
                        {
                            Console.Write("  ");
                        }
                        else if (map[y, x] == 1)
                        {
                            Console.Write("* ");
                        }
                        else
                        {
                            Console.Write("x ");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
