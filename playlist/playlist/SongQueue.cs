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
        private static List<string> navQueue = new List<string>();
        private static bool Once = false;
        public void Queue()
        {
            if (!Once)
            {
                foreach (string s in Play.queueList)
                {
                    navQueue.Add(s);
                }
                Once = true;    
            }
            

            int x = Run();
            if (x == navQueue.Count)
            {
                for (;;)
                {
                    Console.Clear();
                    navQueue.Clear();
                    Play.Flow();
                }

            }
            else if (x == navQueue.Count + 1)
            {
                for (; ; )
                {
                    Console.Clear();
                    navQueue.Clear();
                    Play.Flow();
                }
            }
            else
            {
                arrangeMusic();
            }

        }

        public static void DisplayQueue()
        {

            Console.WriteLine("Music Queue");
            Console.WriteLine("--------------");
            foreach (string s in navQueue)
            {
                Console.WriteLine(s);
            }
            Options(SelectedIndex);

        }

        public static void arrangeMusic() {

            string[] userChoice = {"Play First","Play Before","Play After","Play last"};
            Console.WriteLine("Where do you want to place []?");
        }
        public static void Options(int selectedIndex)
        {
            SelectedIndex = selectedIndex;
            string first = "Back";
            string second = "Save";


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
                Console.WriteLine(second);
            }
            else if (SelectedIndex == navQueue.Count + 1)   
            {
                
                Console.WriteLine(first);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;                
                Console.WriteLine(second);
                Console.ResetColor();
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
                    SelectedIndex = navQueue.Count + 1;
                }
                else if (SelectedIndex == Program.playList.Count + 2)
                {
                    SelectedIndex = 0;
                }


            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;

        }
    }
}
