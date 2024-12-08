using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm
{
    internal class GameController
    {
        private Player _player;
        public GameController()
        {
            _player = new Player();
        }
        public void StartGame()
        {
            Console.WriteLine("What's your name?");
            string playerName = Console.ReadLine();
            if (playerName == "" || playerName == null)
            {
                Console.WriteLine("Okay, I get that you're a little shy, but I already knew your name was Alan Grant.");
                playerName = "Alan Grant";
            }
            Console.WriteLine("Oh no, where did you come from? It's a miracle you're alive.");
            Console.WriteLine($"So this is where you fell while doing archaeological excavations in Gobeklitepe,{_player.Name}.");
            Console.WriteLine($"You survived a fall here and you don't believe in miracles, so let's see if you will continue to think like that even if you get out of here alive,{_player.Name}.");
            Console.WriteLine("Don't worry, I'll help you get out of here. I don't like foreigners.");
            Console.WriteLine("First, I'm going to ask you a simple test question. You'll have to answer these riddles correctly to get out of here.");
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.WriteLine(" What has an eye but cannot see?");
                Console.WriteLine(" Answers");
                Console.WriteLine("1. time");
                Console.WriteLine("2. A wind");
                Console.WriteLine("3. A river");
                Console.WriteLine("4. A needle");
                Console.Write("Answers (1, 2, 3 or 4): ");
                int answer_4 = int.Parse(Console.ReadLine());

                switch (answer_4)
                {
                    case 4:

                        Console.WriteLine($"Well, I hope you can keep it up.,{_player.Name}");
                        isCorrect = true;
                        break;
                    default:
                        Console.WriteLine(" Wrong answer try again.");
                        Console.WriteLine($"Think well or you'll never get out of here,{_player.Name}.");

                        break;
                }
            }
        }
    }
}
