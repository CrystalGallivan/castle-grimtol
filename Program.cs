﻿using System;
using CastleGrimtol.Project;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      Console.BackgroundColor = ConsoleColor.DarkRed;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine(@"


 ___ ___ _______ __  _______ __           _______                            __        _______                   __   
|   Y   |   _   |__||       |  |--.-----.|   _   .-----.----.----.-----.----|  .-----.|   _   .--.--.-----.-----|  |_ 
|.  1   |.  1   |__ |.|   | |     |  -__||   1___|  _  |   _|  __|  -__|   _||_|__ --||.  |   |  |  |  -__|__ --|   _|
|.  _   |.  ____|__|`-|.  |-|__|__|_____||____   |_____|__| |____|_____|__|    |_____||.  |   |_____|_____|_____|____|
|:  |   |:  |         |:  |              |:  1   |                                    |:  1   |                       
|::.|:. |::.|         |::.|              |::.. . |                                    |::..   |                       
`--- ---`---'         `---'              `-------'                                    `----|:.|                       
                                                                                           `--'                       
 ____________________________________________________________________________________________________________________
 ");

      GameService gs = new GameService();
      gs.StartGame();
    }
  }
}
