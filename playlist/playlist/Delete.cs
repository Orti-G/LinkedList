/*
 * Created by SharpDevelop.
 * User: CCSLAB3_PC13
 * Date: 10/12/2024
 * Time: 10:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
namespace playlist
{
	/// <summary>
	/// Description of Delete.
	/// </summary>
	public class Delete
	{
		private static int SelectedIndex;
		private static List<string> musics = new List<string>();
		
		public static void DeleteContent()
		{
			foreach(string music in Program.playList){
				musics.Add(music);
				}
			
			int x = Run();
			
			if ( x == musics.Count)
			{
				for (;;) {
					Console.Clear();
					musics.Clear();
					Program.Main();
				}
				
			}else{
				bool confirmation = ProceedToDelete();
				if(confirmation){
					musics.Remove(musics[SelectedIndex]);
					Program.playList.Clear();
					for (int i = 0; i < musics.Count; i++) {
						Program.playList.AddLast(musics[i]);
					}
					musics.Clear();
					for (;;) {
						Console.Clear();
						DeleteContent();
					}
				}else{
					for (;;) {
						Console.Clear();
						musics.Clear();
						DeleteContent();
					}
				
				}
			}
		}
		
		public static void DisplayText(){

			Console.WriteLine("Music Playlist");
			Console.WriteLine("--------------");
			Options(SelectedIndex);
			
			
			
			
			
			
		}
		
		public static bool ProceedToDelete(){
			
			Console.WriteLine("Are you sure do you want to delete this? (Yes/No)");
			string userInput = Console.ReadLine();
			if (userInput == "Yes") {
				return true;
			}else{
				return false;
			}
		}
		
		public static void Options(int selectedIndex)
		{
			SelectedIndex = selectedIndex;
			string first = "Back";
		
			
			for (int i = 0; i < musics.Count; i++) {
				if (i == SelectedIndex) {
					Console.WriteLine("- " + musics[i]);
				}else{
					Console.WriteLine(musics[i]);
				}
			}
			
			if (SelectedIndex == musics.Count)
			{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				Console.WriteLine(first);
				Console.ResetColor();
			}else{
				Console.WriteLine(first);
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
					
					if (keyPressed == ConsoleKey.S)
					{
						SelectedIndex ++;
						
						
					}
					else if (keyPressed == ConsoleKey.W)
					{
						
						SelectedIndex --;
						
					}
					
					
					if (SelectedIndex == -1){
						SelectedIndex = musics.Count;
					}else if (SelectedIndex == Program.playList.Count + 1)
					{
						SelectedIndex = 0;
					}
				
					
				}while(keyPressed != ConsoleKey.Enter);
				
			return SelectedIndex;
			
		}
	}
}
