/*
 * Created by SharpDevelop.
 * User: CCSLAB3_PC13
 * Date: 10/12/2024
 * Time: 11:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Threading;
namespace playlist
{
	/// <summary>
	/// Description of Play.
	/// </summary>
	public class Play
	{
		public static string musicChoice;
		private static int BottomL;
		private static int BottomR;
		private static int TopL;
		private static int SelectedIndex;
        public static LinkedList<string> queueList = new LinkedList<string>();
        private static bool Once = false;
        private static int totalSongs;
        public static int count = 0;

        public static void PlayMusic(){
			Console.Clear();
			Console.WriteLine("What Music do you want to play?");
			musicChoice = Console.ReadLine();
			if (Program.playList.Contains(musicChoice)){
				foreach (string s in Program.playList) {
					if (s == musicChoice)
					{
						queueList.AddFirst(s);
					}
					else 
					{
						queueList.AddLast(s);
					}
				}
				Console.WriteLine("Please Wait");
				Thread.Sleep(2000);
				Flow();
			}else{
				Console.Clear();
				Console.WriteLine("Music cannot be found");
				Console.ReadLine();
				for(;;){
					Program.Main();
				}
			}
			
			

		}
		
		public static void Flow(){
			SongQueue.Store();
            musicChoice = SongQueue.navQueue[count];
			totalSongs = SongQueue.navQueue.Count;
            int x = Run();
			
            if (x == 0)
            {
                for (; ; )
                {
                    Console.Clear();
					queueList.Clear();
					SongQueue.navQueue.Clear();
					SongQueue.OnceQueue = false;
					Once = false;
					count = 0;
                    Program.Main();
                }
            }

            else if (x == 1)
            {
                for (; ; )
                {
                    SongQueue.Queue();
                }
            }
            else
            {
				traverseQueue();
            }
        }
		public static void traverseQueue() 
		{
			if (count == totalSongs - 1)
			{
				count = 0;
			}
			else 
			{
				count++;
			}

            for (; ; )
            {
                Console.Clear();
				Flow();
            }

        }
		public static void MusicLoaded(){
			Methods method = new Methods();
			Console.Clear();
			borderBox();
			Options(SelectedIndex);

            string text = "Now Playing";
			if (Once == false) {
				method.WriteAt(text,Console.WindowWidth/2 - (text.Length/2),15);
				Thread.Sleep(1000);
				method.WriteAt("\"" + musicChoice + "\"",Console.WindowWidth/2 - (musicChoice.Length/2 + 1),18);
				Once = true;
			}else{
				method.WriteAt(text,Console.WindowWidth/2 - (text.Length/2),15);
				method.WriteAt("\"" + musicChoice + "\"",Console.WindowWidth/2 - (musicChoice.Length/2 + 1),18);
			}
			
		}
		
		public static void Options(int selectedIndex)
		{
			Methods method = new Methods();
			SelectedIndex = selectedIndex;
			string first = "Back";
			string second = "Customize queue";
			string third = "Next";
			
			if (SelectedIndex == 0)
			{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				method.WriteAt(first, TopL + 1,BottomL - 1);
				Console.ResetColor();
                method.WriteAt(second, Console.WindowWidth / 2 - (second.Length / 2), BottomL - 1);
                method.WriteAt(third,BottomR - third.Length, BottomL - 1);
			}
			
			else if (SelectedIndex == 1)
			{
				
				method.WriteAt(first, TopL + 1,BottomL - 1);
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
                method.WriteAt(second, Console.WindowWidth/2 - (second.Length/2),BottomL - 1);
				Console.ResetColor();
                method.WriteAt(third, BottomR - third.Length, BottomL - 1);
			}
			else{
				method.WriteAt(first,TopL + 1,BottomL - 1);
                method.WriteAt(second, Console.WindowWidth / 2 - (second.Length / 2), BottomL - 1);
                Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
                method.WriteAt(third, BottomR - third.Length, BottomL - 1);
                Console.ResetColor();
			}
			
			
		}
		
		public static int Run()
		{

			ConsoleKey keyPressed;
				do
				{
					
					Console.Clear();
					MusicLoaded();
					
					
					ConsoleKeyInfo keyInfo = Console.ReadKey(true);
					keyPressed = keyInfo.Key;
					
					if (keyPressed == ConsoleKey.D)
					{
						SelectedIndex ++;
						
						
					}
					else if (keyPressed == ConsoleKey.A)
					{
						
						SelectedIndex --;
						
					}
					
					
					if (SelectedIndex == -1){
						SelectedIndex = 2;
					}else if (SelectedIndex == 3)
					{
						SelectedIndex = 0;
					}
				
					
				}while(keyPressed != ConsoleKey.Enter);
				
			return SelectedIndex;
			
		}
		
		public static void borderBox(){
		Methods method = new Methods();
			int topL = 0;
			int topR = 0;
			int bottomL = 0;

			
			for (int i = 0; i < 15; i++) {
   				method.WriteAt("*",Console.WindowWidth/2 - i ,10);
   				topL = Console.WindowWidth/2 - i;
				TopL = topL;

               }
   			
   			for (int i = 0; i < 15; i++) {
				method.WriteAt("*",Console.WindowWidth/2 + i ,10);
   				topR = Console.WindowWidth/2 + i;	
   				
   				
   			}
			
   			
   			for (int i = 1; i < 15; i++) {
   				method.WriteAt("*",topL, 10 + i);
   				bottomL = 10 + i;
   				BottomL = bottomL;
   				
   			}
   			
   			for (int i = 0; i < 30; i++) {
   				method.WriteAt("*",topL + i,bottomL);
   				BottomR =topL + i;
			}

            for (int i = 0; i < 30; i++)
            {
                method.WriteAt("*", topL + i, bottomL - 2);
            }

            for (int i = 0; i < 15; i++) {
   				method.WriteAt("*",Console.WindowWidth/2 + 15 ,bottomL - i);
   			}
		}
	}
}
