/*
 * Created by SharpDevelop.
 * User: CCSLAB3_PC13
 * Date: 10/12/2024
 * Time: 10:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace playlist
{
	/// <summary>
	/// Description of Add.
	/// </summary>
	public class Add
	{
		private static int SelectedIndex;
		private static int Once;
		private static string musicTitle;
		
		public void AddSection()
		{
			
			int x = Run();
			
			if ( x == 0)
			{
	
				for (;;) {
					Console.Clear();
					Program.playList.AddLast(musicTitle);
					musicTitle = "";
					Once = 0;
					Program.Main();
				}
				
			}
			
			else if (x == 1)
			{
				for (;;) {
					Program.Main();
				}
			}
			Console.ReadKey(true);
		}
		
		public static void DisplayText(){
			Console.WriteLine("What music do you want to add?");
			Console.Write("Title: " + musicTitle);
			if (Once == 1) {
				Console.WriteLine();
				Options(SelectedIndex);
			}else{
				musicTitle = Console.ReadLine();
				Once++;
				Options(SelectedIndex);
			}
			
		}
		
		public static void Options(int selectedIndex)
		{
			SelectedIndex = selectedIndex;
			string first = "Add";
			string second = "Back";
			
			if (SelectedIndex == 0)
			{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				Console.WriteLine(first);
				Console.ResetColor();
				Console.WriteLine(second);
			}
			
			else if (SelectedIndex == 1)
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
						SelectedIndex = 1;
					}else if (SelectedIndex == 2)
					{
						SelectedIndex = 0;
					}
				
					
				}while(keyPressed != ConsoleKey.Enter);
				
			return SelectedIndex;
			
		}
	}
}
