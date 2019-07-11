using System;
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
      Console.WriteLine(@"

  _____ _             _   
 / ____| |           | |  
| (___ | |_ __ _ _ __| |_ 
 \___ \| __/ _` | '__| __|
 ____) | || (_| | |  | |_ 
|_____/ \__\__,_|_|   \__|

");
      Console.WriteLine("Press any Key to Begin!");
      Console.ReadKey();
    }

    public virtual void Go(string direction)
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
      Console.WriteLine($"{CurrentRoom.Description}");
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
      Room tfcorridor = new Room("Third Floor Corridor", "You stumble into a dark dank room. In the middle of the room is a giant black three headed dog. Fortunatly the dog is chained up. He snarles and strains against his chain. There is a trapdoor underneath one of the dogs giant paws.");
      Room tunnel = new Room("Tunnel of Devil's Snare", "After a long dark drop you've landed on a bed of an odd looking plant. You move a little and the plant starts wrapping itself around you.");
      Room keyChamber = new Room("Keys Chamber", "Free of the Devil's Snare you find yourself in a downwards sloping passage with stone walls, through which trickling water can be heard, you can see a brilliantly lit chamber with a very high ceiling, full of glittering winged keys. On the opposite end of the chamber from the stone passage is a large, old-fashioned wooden door with a silver lock.");
      Room chessChamber = new Room("Chessboard Chamber", "Your eyes have to adjust as you enter a dark chamber with looming silhouettes of what appears to be giant chess pieces.");
      Room trollChamber = new Room("Troll Chamber", "An foul stench and stale air flood your sense as you enter the next chamber. Standing before you is a massive mountain troll. Drool is spilling out the side of his mouth as he try's to focus his squinty eyes on you.");
      Room pChamber = new Room("Poison Chamber", "Final a lit room! You quickly enter the room. Purple flames immediatly burst up behind you leap forward only to see black flames raging on the opposite side of the room. You're trapped! A table holding seven labelless potion bottles of differing shapes and sizes sits in the centre of the room.");
      Room meChamber = new Room("Mirror of Erisid Chamber", "A large flame lit room spans before you. Walls of stone with intrict designs carved into them surround you with flame lit torches mounted on them. Off in the distance you see the Mirror of Erisid glinting at you. You feel eyes on you.");


      // Exits
      tfcorridor.Exits.Add("forward", tunnel);
      tunnel.Exits.Add("right", keyChamber);
      keyChamber.Exits.Add("forward", chessChamber);
      chessChamber.Exits.Add("forward", trollChamber);
      trollChamber.Exits.Add("north", pChamber);
      pChamber.Exits.Add("north", meChamber);
      meChamber.Exits.Add("left", tfcorridor);


      // Items
      Item harp = new Item("Harp", "A gold harp.");
      Item wand = new Item("Wand", "11\" holly, phoenix feather, nice and supple");
      Item broom = new Item("Broom", "What it may lack in speed and flashiness, it makes up with sturdiness and dependability. A good broom that will take care of most of your needs.");
      Item falseKey = new Item("Key", "A glittering winged key.");
      Item key = new Item("Key", "A glittering winged key with a crumpled wing.");
      Item stone = new Item("The Sorcer's Stone", "A legendary substance with astonishing powers. The Stone will transform any metal into pure gold. It also produces the Elixir of Life, which will make the drinker immortal.");

      tfcorridor.Items.Add(harp);
      keyChamber.Items.Add(broom);
      keyChamber.Items.Add(falseKey);
      keyChamber.Items.Add(key);
      meChamber.Items.Add(stone);


      CurrentPlayer.Inventory.Add(wand);
      CurrentRoom = tfcorridor;
    }

    public void StartGame()
    {



    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {
      // if (Item.Used == false)
      // {
      //   Item.Used = true;
      // }

    }


    public GameService(Room currentRoom, Player currentPlayer)
    {
      CurrentRoom = currentRoom;
      CurrentPlayer = currentPlayer;
      Setup();
    }
  }
}