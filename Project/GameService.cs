using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {

    }

    public void Go(string direction)
    {

    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    { //takes in a current room
      //console write currentroom.description

    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }

    public void Setup()
    //Initializes the game, creates rooms, their exits, and add items to rooms
    { // Add Rooms
      // IRoom tfcorridor = new IRoom("Third Floor Corridor");
      // Exits
      // Items

    }

    public void StartGame()
    {

    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }

    public GameService(Room currentRoom, Player currentPlayer)
    {
      CurrentRoom = currentRoom;
      CurrentPlayer = currentPlayer;
    }
  }
}