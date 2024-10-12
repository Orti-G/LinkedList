/*
 * Created by SharpDevelop.
 * User: CCSLAB3_PC13
 * Date: 10/12/2024
 * Time: 10:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace playlist
{
	/// <summary>
	/// Description of Method.
	/// </summary>
	public class Methods
	{
		
			private static int origRow = 0;
	    private static int origCol = 0;
	    
	    
		public void WriteAt(string s, int x, int y)
	    {
	    try
	        {
	        Console.SetCursorPosition(origCol+x, origRow+y);
	        Console.Write(s);
	        }
	    catch (ArgumentOutOfRangeException)
	        {        
	        Console.Write("");
	        }
	    }
	    
	    public void WriteAt(char s, int x, int y)
	    {
	    
	        Console.SetCursorPosition(origCol+x, origRow+y);
	        Console.Write(s);
	        
	   
	    }
	    
	    public void WriteAt(int s, int x, int y)
	    {
	    
	        
	        Console.SetCursorPosition(origCol+x, origRow+y);
	        Console.Write(s);
	        
	    
	    }
	    
	    public void WriteAt(double s, int x, int y)
	    {
	    
	        
	        Console.SetCursorPosition(origCol+x, origRow+y);
	        Console.Write(s);
	        
	    
	    }
		
	}
}
