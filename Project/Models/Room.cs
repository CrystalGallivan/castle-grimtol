using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    //props
    public Room Next { get; private set; }
    public Room Previous { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    // public Dictionary<string, Room> Chamber { get; set; }

    //methods
    public void AddNextRoom(Room next)
    {
      Next = next;
      next.AddPreviousRoom(this);
    }
    public void AddPreviousRoom(Room previous)
    {
      Previous = previous;
    }
    private IRoom GoToExit(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      Console.WriteLine("Wrong Way");
      return this;
    }
    public IRoom Go(string direction)
    {
      switch (direction)
      {
        case "previous":
          if (Previous != null) return Previous;
          return this;
        case "next":
          if (Next != null) return Next;
          return this;
        default:
          return GoToExit(direction);
      }
    }
    public void PrintOption()
    {
      Console.Write("Type 'forward', 'back', 'left', or 'right' to move.");
      foreach (var exit in Exits)
      {
        Console.Write(exit.Key + " : ");
      }
    }



    //constructor
    public Room(string name, string description) : base()
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
      // Chamber = new Dictionary<string, Room>();
    }
  }
}