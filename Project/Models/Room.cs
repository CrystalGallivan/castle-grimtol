using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    //props
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    //methods

    public IRoom Navigate(string option)
    {
      Console.WriteLine($"{Name} -- {Description}");
      Console.Clear();
      if (Exits.ContainsKey(option))
      {
        Console.WriteLine($"{Exits[option].Name} --- {Exits[option].Description}");
        return Exits[option];

      }
      Console.WriteLine("Invalid location.");
      return this;
    }
    public void PrintOption()
    {
      Console.WriteLine(@"Options:
      To Move: Type 'go forward', 'go back', 'go left', or 'go right' to move.
      To see Inventory: Type 'inventory'
      To Take Item: Type 'take' + item name
      To Use Item: Type 'use' + item name
      For Help: Type 'help'
      To see the room: Type 'look'
      To Restart: Type 'restart' 
      To Quit: Type 'quit' ");

    }





    //constructor
    public Room(string name, string description) : base()
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}