using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist
{
    public class SongQueue
    {
        private static int SelectedIndex;
        public static List<string> navQueue = new List<string>();
        public static bool OnceQueue = false;
        public static void Queue()
        {
            Store();

            int x = Run();
            if (x == navQueue.Count)
            {
                for (;;)
                {
                    Console.Clear();
                    navQueue.Clear();
                    OnceQueue = false;
                    Play.Flow();
                }

            }
            else
            {
                arrangeMusic();
            }

        }

        public static void Store() 
        {
            if (!OnceQueue)
            {
                foreach (string s in Play.queueList)
                {
                    navQueue.Add(s);
                }

                OnceQueue = true;
            }
        }

        public static void DisplayQueue()
        {

            Console.WriteLine("Music Queue");
            Console.WriteLine("--------------");
            Options(SelectedIndex);

        }

        public static void arrangeMusic() {
            Console.WriteLine("Where do you want to place ["+ navQueue[SelectedIndex] + "]?");
            Console.WriteLine("a. Play First");
            Console.WriteLine("b. Play Before");
            Console.WriteLine("c. Play After");
            Console.WriteLine("d. Play last");
            Console.WriteLine("e. Back");
            Console.Write("----> ");
            char userInput = char.Parse(Console.ReadLine());

            if (userInput == 'a')
            {
                Play.queueList.Remove(navQueue[SelectedIndex]);
                Play.queueList.AddFirst(navQueue[SelectedIndex]);
                navQueue.Clear();
                OnceQueue = false;
                for (; ; )
                {
                    Console.Clear();
                    SelectedIndex = 0;
                    Play.count = 0;
                    Queue();
                }
            }
            else if (userInput == 'b')
            {
                Play.queueList.Remove(navQueue[SelectedIndex]);
                Console.Write("Play before what song?");
                string userChangeBefore = Console.ReadLine();
                Play.queueList.AddBefore(Play.queueList.Find(userChangeBefore), navQueue[SelectedIndex]);
                navQueue.Clear();
                OnceQueue = false;
                for (; ; )
                {
                    Console.Clear();
                    SelectedIndex = 0;
                    Play.count = 0;
                    Queue();
                }
            }
            else if (userInput == 'c')
            {
                Play.queueList.Remove(navQueue[SelectedIndex]);
                Console.Write("Play before what song?");
                string userChangeAfter = Console.ReadLine();
                Play.queueList.AddAfter(Play.queueList.Find(userChangeAfter), navQueue[SelectedIndex]);
                navQueue.Clear();
                OnceQueue = false;
                for (; ; )
                {
                    Console.Clear();
                    SelectedIndex = 0;
                    Play.count = 0;
                    Queue();
                }
            }
            else if (userInput == 'd') 
            {
                Play.queueList.Remove(navQueue[SelectedIndex]);
                Play.queueList.AddLast(navQueue[SelectedIndex]);
                navQueue.Clear();
                OnceQueue = false;
                for (; ; )
                {
                    Console.Clear();
                    SelectedIndex = 0;
                    Play.count = 0;
                    Queue();
                }
            }
            else
            {
                for (; ; )
                {
                    Console.Clear();
                    Queue();
                }
            }

        }
        public static void Options(int selectedIndex)
        {
            SelectedIndex = selectedIndex;
            string first = "Back";


            for (int i = 0; i < navQueue.Count; i++)
            {
                if (i == SelectedIndex)
                {
                    Console.WriteLine("* " + navQueue[i]);
                }
                else
                {
                    Console.WriteLine(navQueue[i]);
                }
            }


            if (SelectedIndex == navQueue.Count)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(first);
                Console.ResetColor();

            }
            else 
            {
                Console.WriteLine(first);          
            }


        }

        public static int Run()
        {

            ConsoleKey keyPressed;
            do
            {

                Console.Clear();
                DisplayQueue();


                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.S)
                {
                    SelectedIndex++;


                }
                else if (keyPressed == ConsoleKey.W)
                {

                    SelectedIndex--;

                }


                if (SelectedIndex == -1)
                {
                    SelectedIndex = navQueue.Count;
                }
                else if (SelectedIndex == Program.playList.Count + 1)
                {
                    SelectedIndex = 0;
                }


            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;

        }
    }
}
