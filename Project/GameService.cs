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
    public bool Playing { get; set; } = true;
    //methods

    public void Play()
    {
      Console.WriteLine("What is your Name?");
      string playerName = Console.ReadLine();
      Player CurrentPlayer = new Player(playerName);
      Console.Clear();
      Console.WriteLine($"Welcome {CurrentPlayer.PlayerName}!");
      Console.WriteLine(@"Welcome you are on a mission to retrieve the Sorcer's Stone. Harry Potter is no where to be found. Professor Quirrell must be stopped. You must make you're way through a series of challanges that will push your limits. Navigate your way through the rooms by typing 'go forward', 'go right', 'go left', 'go back'. To open your inventory type 'inventory'. To pick up an item type 'take'. To use an item type 'use'. To look around type 'look'. For help type 'help'. If you're a quitter you can also type 'quit. ");
      Console.WriteLine($@"{CurrentRoom.Name} -
     {CurrentRoom.Description}");
      while (Playing)
      {
        GetUserInput();
      }
    }
    public void GetUserInput()
    {

      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower();
      string[] inputs = input.Split(" ");
      string command = inputs[0];
      string option = "";
      if (inputs.Length > 1)
      {
        option = inputs[1];
      }
      switch (command)
      {
        case "lose":
          Lose(option);
          break;
        case "go":
          Go(option);
          break;
        case "take":
          TakeItem(option);
          break;
        case "use":
          UseItem(option);
          break;
        case "look":
          Look();
          break;
        case "help":
          Help();
          break;
        case "restart":
          Reset();
          break;
        case "quit":
          Quit();
          break;
      }
      CurrentRoom.PrintOption();

    }


    public void Go(string option)
    {
      //TODO  I need to reset currentroom every time the room changes
      CurrentRoom = (Room)CurrentRoom.Navigate(option);

      Console.WriteLine("Type 'go forward', 'go back', 'go right', 'go left' to move.");

    }

    public void Help()
    {
      CurrentRoom.PrintOption();
    }

    public void Inventory()
    {
      Console.WriteLine("Welcome to your Inventory");
      int count = 1;
      foreach (var item in CurrentPlayer.Inventory)
      {
        Console.WriteLine($"{count}) {item.Name} - {item.Description}");
        count++;
      }
      Console.WriteLine("Would you Like to use and item?");
      string answer = Console.ReadLine().ToLower();
      if (answer == "use")
      {
        Console.WriteLine("Type item name to select.");
        string option = Console.ReadLine().ToLower();
        UseItem(option);
      }
      Console.WriteLine("Type 'close' to close your inventory.");


    }

    public void Look()
    { //takes in a current room
      //console write currentroom.description
      Console.WriteLine($"{CurrentRoom.Name} - {CurrentRoom.Description}");
      foreach (var exit in CurrentRoom.Exits)
      {
        Console.WriteLine($"{exit}");
      }
    }

    public void Quit()
    {
      Playing = false;
      //TODO Will this work?
    }

    public void Reset()
    {
      Console.Clear();
      StartGame();
      Setup();
      Play();
    }

    public void Setup()
    //Initializes the game, creates rooms, their exits, and add items to rooms
    { // Add Rooms
      Room tfcorridor = new Room("Third Floor Corridor", "You stumble into a dark dank room. In the middle of the room is a giant black three headed dog. Fortunatly the dog is chained up. He snarles and strains against his chain. There is a trapdoor underneath one of the dogs giant paws. There is a harp lying on the floor next to you.");
      Room tunnel = new Room("Tunnel of Devil's Snare", "After a long dark drop you've landed on a bed of an odd looking plant. You move a little and the plant starts wrapping itself around you. You remember that you have a wand in your robe pocket.");
      Room keyChamber = new Room("Keys Chamber", "Free of the Devil's Snare you find yourself in a downwards sloping passage with stone walls, through which trickling water can be heard, you can see a brilliantly lit chamber with a very high ceiling, full of glittering winged keys. On the opposite end of the chamber from the stone passage is a large, old-fashioned wooden door with a silver lock and a broom propped next to it.");
      Room chessChamber = new Room("Chessboard Chamber", "Your eyes have to adjust as you enter a dark chamber with looming silhouettes of what appears to be giant chess pieces.");
      Room trollChamber = new Room("Troll Chamber", "An foul stench and stale air flood your sense as you enter the next chamber. Standing before you is a massive mountain troll. Drool is spilling out the side of his mouth as he try's to focus his squinty eyes on you.");
      Room pChamber = new Room("Poison Chamber", "Final a lit room! You quickly enter the room. Purple flames immediatly burst up behind you leap forward only to see black flames raging on the opposite side of the room. You're trapped! A table holding seven labelless potion bottles of differing shapes and sizes sits in the centre of the room.");
      Room meChamber = new Room("Mirror of Erisid Chamber", "A large flame lit room spans before you. Walls of stone with intrict designs carved into them surround you with flame lit torches mounted on them. Off in the distance you see the Mirror of Erisid glinting at you. You feel eyes on you.");


      // Exits
      tfcorridor.Exits.Add("forward", tunnel);
      tunnel.Exits.Add("back", tfcorridor);
      tunnel.Exits.Add("right", keyChamber);
      keyChamber.Exits.Add("left", tunnel);
      keyChamber.Exits.Add("forward", chessChamber);
      chessChamber.Exits.Add("back", keyChamber);
      chessChamber.Exits.Add("forward", trollChamber);
      trollChamber.Exits.Add("back", chessChamber);
      trollChamber.Exits.Add("right", pChamber);
      pChamber.Exits.Add("left", trollChamber);
      pChamber.Exits.Add("right", meChamber);
      meChamber.Exits.Add("right", pChamber);
      meChamber.Exits.Add("forward", tfcorridor);


      // Items
      Item harp = new Item("Harp", "You pick up the harp and start playing. The dog stop snarling, it's big eyes start to droop. Finally the dogs heads drop. His paw is just far enough off of the trap door take open it and slip through.");
      Item wand = new Item("Wand", "You find a, 11\" holly, phoenix feather, nice and supple, wand hidden in your robes. You shout incendio. The devil's snare quickly recedes. You can feel your self falling again.");
      Item broom = new Item("Broom", "What it may lack in speed and flashiness, it makes up with sturdiness and dependability. A good broom that will take care of most of your needs. You grab a hold of it and whisks you up ward towards the keys floating above.");
      Item falseKey = new Item("Key", "A glittering winged key. You grab the key as it try's to dart away. This key does not fit the key hole on the door");
      Item key = new Item("Key", "A glittering winged key with a crumpled wing. You easily snatch the key. You take it to the door and try it. It's a perfect match.");
      Item stone = new Item("The Sorcer's Stone", "A legendary substance with astonishing powers. The Stone will transform any metal into pure gold. It also produces the Elixir of Life, which will make the drinker immortal. You have saved the word from Professor Quirrell and he who must not be named. You have won this round!");

      //Add Items to Room
      tfcorridor.Items.Add(harp);
      keyChamber.Items.Add(broom);
      keyChamber.Items.Add(falseKey);
      keyChamber.Items.Add(key);
      meChamber.Items.Add(stone);



      // CurrentPlayer.Inventory.Add(wand);

      CurrentRoom = tfcorridor;
    }

    public void StartGame()
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
      Play();

    }

    public void TakeItem(string option)
    {
      //TODO Figure out why this isn't working
      Console.Clear();
      Item item = CurrentRoom.Items.Find(i => i.Name == option);
      if (item != null)
      {
        Console.WriteLine($"{item.Name} --- {item.Description}");
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        Console.WriteLine($"Sucessfully added");
      }
      else
      {
        Console.WriteLine("That is not an item!");

      }

    }


    public void UseItem(string option)
    {
      //TODO Figure out why this isn't working
      Console.Clear();
      Item item = CurrentRoom.Items.Find(i => i.Name == option);
      if (item != null)
      {
        Console.WriteLine($"{item.Name} --- {item.Description}");
        CurrentRoom.Items.Add(item);
        CurrentPlayer.Inventory.Remove(item);
        Console.WriteLine($"{item.Description}");
      }
      else
      {
        Console.WriteLine("That is not an item!");

      }

    }
    public void Lose(string option)
    {
      if (CurrentRoom.Name == "Poison Chamber" && option == "left")
      {
        Console.WriteLine("You stepped back through the purple flames and burned to a crisp!");
        Playing = false;
      }
      //TODO decide on losing conditions
    }

    //constructor
    public GameService()
    {

      Setup();
    }
  }


}