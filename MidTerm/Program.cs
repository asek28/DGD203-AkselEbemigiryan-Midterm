using System;
using System.Security.Cryptography.X509Certificates;

namespace MidTerm
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            GameController controller = new GameController();

            controller.StartGame();


            int[,] map = {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 2, 0, 0, 0, 8, 1, 1, 1, 1, 0},
                {0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
                {0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
                {0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0},
                {0, 0, 1, 7, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0},
                {0, 0, 3, 0, 0, 5, 0, 0, 0, 1, 0, 1, 1, 0},
                {0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 4, 1, 6, 0, 1, 1, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 10, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

            };
            int[,] map2 =  {
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 2, 0, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 0},
                {0, 0, 1, 0, 1, 0, 1, 0},
                {0, 0, 0, 0, 0, 0, 1, 0},
                {0, 1, 0, 0, 0, 1, 1, 0},
                {0, 0, 1, 7, 1, 1, 1, 0},
                {0, 0, 4, 0, 0, 5, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},

            };

            int playerX = 1, playerY = 1;
            bool hasKey = false;
            bool hasGem = false;
            bool hasRope = false;
            bool hasTNT = false;
            bool pass_3 = false;
            bool pass_4 = false;
            bool pass_10 = false;
            
            Inventory inventory = new Inventory();
            while (true)
            {
                //Labirenti ekrana çizdirme
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        if (x == playerX && y == playerY)
                        {
                            Console.Write("O");
                        }
                        else if (map[x, y] == 7)
                        {
                            Console.Write("?");
                        }
                        /*else if (map2[x, y] == 3)
                        {
                            Console.Write("/");
                        }
                        else if (map2[x, y] == 4)
                        {
                            Console.Write("_");
                        }
                        else if (map2[x, y] == 9)
                        {
                            Console.Write("|");
                        }
                        else if (map2[x, y] == 8)
                        {
                            Console.Write("&");
                        }
                        else if (map2[x, y] == 10)
                        {
                            Console.Write("!");
                        }*/
                        else
                        {
                            Console.Write(map[x, y] == 0 ? "#" : " ");
                        }
                    }
                    Console.WriteLine();
                }

                //Movement
                Console.Write("Movement (w, a, s, d): ");
                char movement = Console.ReadKey().KeyChar;



                //Konum değiştirme
                int newX = playerX, newY = playerY;
                switch (movement)
                {
                    case 'w': newY--; break;
                    case 's': newY++; break;
                    case 'a': newX--; break;
                    case 'd': newX++; break;
                }

                
                //Yeni konumlar
                if (newX >= 0 && newX < map.GetLength(0) &&
                    newY >= 0 && newY < map.GetLength(1) &&
                    pass_3 || map[newX, newY] != 3 &&
                    pass_4 || map[newX, newY] != 4 &&
                    pass_10 || map[newX, newY] != 10 &&
                    map[newX, newY] != 0)

                {
                    playerX = newX;
                    playerY = newY;


                    // Yukarı çıkış için ip 3 numara.
                    if (map[playerX, playerY] == 3 && inventory.HasItem("Rope"))
                    {
                        
                        //Game nextGame = new Game();
                        //nextGame.StartGame();
                        for (int y = 0; y < map2.GetLength(1); y++)
                        {
                            for (int x = 0; x < map2.GetLength(0); x++)
                            {
                                if (x == playerX && y == playerY)
                                {
                                    Console.Write("O");
                                }
                                else if (map2[x, y] == 7)
                                {
                                    Console.Write("?");
                                }
                                else
                                {
                                    Console.Write(map2[x, y] == 0 ? "#" : " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        pass_3 = true;
                        if (map[playerX, playerY] == 3)
                        {
                            pass_3 = false;
                        }
                        Console.WriteLine(" Even though it was difficult, you managed to go up using your rope, come on, keep going.");
                        

                    }
                    else if (map[playerX, playerY] == 3 && !inventory.HasItem("Rope"))
                    {
                        Console.WriteLine(" You need a rope to up stairs.");
                    }

                    //Kapı açma 4 numara.
                    else if (map[playerX, playerY] == 4)
                    {
                        Console.WriteLine(" I have spaces, but no rooms. I have mountains, but no trees. I have water, but no fish. What am I?");
                        Console.WriteLine(" Answers");
                        Console.WriteLine("1. A moon");
                        Console.WriteLine("2. A map");
                        Console.WriteLine("3. A star");
                        Console.WriteLine("4. A cloud");
                        Console.Write("Answers (1, 2, 3 or 4): ");
                        int answer_2 = int.Parse(Console.ReadLine());

                        switch (answer_2)
                        {
                            case 2:
                                
                                Console.WriteLine(" Congratulations on the right answer.");
                                pass_4 = true;
                                if (map[playerX, playerY] == 4)
                                {
                                    pass_4 = false;
                                }
                                map[playerX, playerY] = 9;
                                break;
                            default:
                                Console.WriteLine(" Wrong answer try again.");
                                return;
                        }

                    }
                    

                    //Gem almak için 8 numara
                    else if (map[playerX, playerY] == 8 && inventory.HasItem("TNT"))
                    {
                        inventory.AddItem("Gem");
                        hasGem = true;
                        map[playerX, playerY] = 1;
                        Console.WriteLine(" I have no branches, but I can grow very tall. I have no voice, but I can tell you many stories. What am I?");
                        Console.WriteLine(" Answers");
                        Console.WriteLine("1. A storm");
                        Console.WriteLine("2. A map");
                        Console.WriteLine("3. A tree");
                        Console.WriteLine("4. A rope");
                        Console.Write("Answers (1, 2, 3 or 4): ");
                        int answer_3 = int.Parse(Console.ReadLine());

                        switch (answer_3)
                        {
                            case 3:
                                
                                Console.WriteLine(" Congratulations on the right answer.");
                                Console.WriteLine(" The gems are active, you can open the sealed door now.");
                                break;
                            default:
                                Console.WriteLine(" Wrong answer try again.");
                                hasGem = false;
                                map[playerX, playerY] = 8;
                                return;
                        }

                    }
                    else if (map[playerX, playerY] == 8 && !inventory.HasItem("TNT"))
                    {
                        Console.WriteLine(" You need TNT to blow it up.");
                        Console.WriteLine(" Please search around.");
                    }
                    //Anahter 5 numara.
                    else if (map[playerX, playerY] == 5)
                    {
                        inventory.AddItem("Key");
                        hasKey = true;

                        map[playerX, playerY] = 1;

                    }

                    //Sandık açma 7 numara
                    else if (map[playerX, playerY] == 7 && inventory.HasItem("Key"))
                    {
                        Console.WriteLine(" Chest opened and a rope came out of it.");
                        inventory.AddItem("Rope");
                        hasRope = true;
                        map[playerX, playerY] = 1;
                    }
                    else if (map[playerX, playerY] == 7 && !inventory.HasItem("Key"))
                    {
                        Console.WriteLine(" You need the key to open this chest.");
                    }
                    //Dinamit alma 6 numara.
                    else if (map[playerX, playerY] == 6)
                    {
                        inventory.AddItem("TNT");
                        hasTNT = true;
                        map[playerX, playerY] = 1;

                    }
                    //Oyunu bitirme son kapı 10 numara. 
                    else if (map[playerX, playerY] == 10 && inventory.HasItem("Gem"))
                    {
                        pass_10 = true;
                        Console.WriteLine(" I am always coming, but also always going. I am present, but also past. What am I?");
                        Console.WriteLine(" Answers");
                        Console.WriteLine("1. time");
                        Console.WriteLine("2. A wind");
                        Console.WriteLine("3. A river");
                        Console.WriteLine("4. A shadow");
                        Console.Write("Answers (1, 2, 3 or 4): ");
                        int answer_1 = int.Parse(Console.ReadLine());

                        switch (answer_1)
                        {
                            case 1:

                                Console.WriteLine(" Congratulations on the right answer.");
                                
                                Console.WriteLine(" Congratulations you managed to get out of this labyrinthine dungeon.");
                                break;
                            default:
                                Console.WriteLine(" Wrong answer try again.");
                                Console.WriteLine(" It's a shame to come all the way here and say you lost the game, your life.");
                                map[playerX, playerY] = 10;
                                return;
                        }
                        
                        
                    }
                    else if (map[playerX, playerY] == 10 && !inventory.HasItem("Gem"))
                    {
                        Console.WriteLine(" You need gem to open this door.");
                        Console.WriteLine(" Please search around.");


                    }

                }
            }

        }
 
    }
}