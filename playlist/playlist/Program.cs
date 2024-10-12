/*
 * Created by SharpDevelop.
 * User: CCSLAB3_PC13
 * Date: 10/12/2024
 * Time: 10:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace playlist
{
	class Program
	{
		private static int SelectedIndex;
		public static LinkedList<string> playList = new LinkedList<string>();
		
		public static void Main()
		{
			Console.CursorVisible = false;
			int x = Run();
			
			if ( x == 0)
			{
				Add addMusic = new Add();
				Console.Clear();
				addMusic.AddSection();
			}
			
			else if (x == 1)
			{
				Delete.DeleteContent();
			}
			else{
				Play playSection = new Play();
				playSection.PlayMusic();
			}
			Console.ReadKey(true);
		}
		
		public static void DisplayText(){
			Console.WriteLine("Music Playlist");
			Console.WriteLine("--------------");
			if (playList.Count == 0) {
				Console.WriteLine("<no music>");
			}else{
				foreach(string music in playList){
					Console.WriteLine(music);
				}
			}
			Console.WriteLine("--------------");
			Options(SelectedIndex);
		}
		
		public static void Options(int selectedIndex)
		{
			SelectedIndex = selectedIndex;
			string first = "Add";
			string second = "Delete";
			string third = "Play";
			
			if (SelectedIndex == 0)
			{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				Console.WriteLine(first);
				Console.ResetColor();
				Console.WriteLine(second);
				Console.WriteLine(third);
			}
			
			else if (SelectedIndex == 1)
			{
				
				Console.WriteLine(first);
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				Console.WriteLine(second);
				Console.ResetColor();
				Console.WriteLine(third);
			}
			else{
				Console.WriteLine(first);
				Console.WriteLine(second);
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				Console.WriteLine(third);
				Console.ResetColor();
			}
			
			
		}
		
		public static int Run()
		{

			ConsoleKey keyPressed;
				do
				{
					
					Console.Clear();
					DisplayText();
					
					
					ConsoleKeyInfo keyInfo = Console.ReadKey(true);
					keyPressed = keyInfo.Key;
					
					if (keyPressed == ConsoleKey.DownArrow)
					{
						SelectedIndex ++;
						
						
					}
					else if (keyPressed == ConsoleKey.UpArrow)
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
	}
}