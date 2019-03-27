using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGameV2
{
    public class App
    {
        List<Planet> locations = new List<Planet>();
        List<Player> players = new List<Player>();
        List<Ship> ships = new List<Ship>();
        List<Item> items = new List<Item>();
        Player myPlayer;
        Ship myShip;
        Planet myLocation;
        public double distance;
        public App()
        {
            items.Add(new Item(
                               "Ruby",
                               1000
                              ));
            items.Add(new Item(
                               "Gems",
                               3000
                              ));
            items.Add(new Item(
                               "Ruby",
                               5000
                              ));
            items.Add(new Item(
                               "Leather",
                               1500
                              ));
            items.Add(new Item(
                               "Goats milk",
                               300
                              ));

            locations.Add(new Planet(
                                        "Earth",
                                        "This is planet Earth",
                                        5.21,
                                        2.45,
                                        1.2
                                     ));
            locations.Add(new Planet(
                                        "Uberon",
                                        "This is planet Uberon",
                                        7.21,
                                        1.45,
                                        2.5
                                     ));
            locations.Add(new Planet(
                                        "Alpha",
                                        "This is planet Alpha",
                                        10.21,
                                        4.45,
                                        5.2
                                     ));
            locations.Add(new Planet(
                                        "Mars",
                                        "This is planet Mars",
                                        12.32,
                                        6.21,
                                        8
                                     ));
            locations.Add(new Planet(
                                        "Neptune",
                                        "This is planet Neptune",
                                        4.32,
                                        3.21,
                                        0.5
                                     ));
            players.Add(new Player(
                                        10,                        
                                        "Jimbo",
                                        20,
                                        100000,
                                        new List<Item>()
                                  ));
            players.Add(new Player(
                                        10,
                                        "Jammy",
                                        20,
                                        100000,
                                        new List<Item>()
                                  ));
            players.Add(new Player(
                                        10,
                                        "Kara",
                                        20,
                                        100000,
                                        new List<Item>()
                                  ));
            ships.Add(new Ship(
                                        "Planet Express",
                                        30
                              ));
            ships.Add(new Ship(
                                        "My First Ship",
                                        40
                              ));
            ships.Add(new Ship(
                                        "Galaxy 8",
                                        25
                              ));

            myLocation = locations[0];
        }

        public void Run()
        {
            EventLoop();
        }

        public void EventLoop()
        {
           bool test = true;
            do
            {
                test = SelectCharacter();
            } while (test);
        }

        public bool SelectCharacter()
        {
            bool test = true;
            try
            {
                //while (test)
                {
                    Console.WriteLine("Choose a character:\n");

                    for (int x = 0; x < players.Count; x++)
                    {
                        Console.WriteLine($"{x + 1}: {players[x].name}");
                    }
                    string key = Console.ReadLine();

                    if (key == "quit")
                    {
                        
                        return Quit();
                    }
                        

                    myPlayer = players[Convert.ToInt32(key) - 1];
                    test = SelectShip();
                }
            }
            catch(Exception)
            {
                Console.Clear();
                SelectCharacter();
            }

            return false;
            
        }

        public bool SelectShip()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Choose a ship:\n");

                for (int x = 0; x < ships.Count; x++)
                {
                    Console.WriteLine($"{x + 1}: {ships[x].name}");
                }
                string key = Console.ReadLine();

                if (key == "quit")
                    return Quit();


                myShip = ships[Convert.ToInt32(key) - 1];
                OptionsMenu();
            }
            catch(Exception)
            {
                SelectShip();
            }
            
            
            return false;
        }

        public bool OptionsMenu()
        {
            Console.Clear();
            Console.WriteLine($"Name: {myPlayer.name}\tAge:{myPlayer.age:f2}\tShip: {myShip.name}\tMoney: {myPlayer.money}\tCargo{myPlayer.cargo}");
            for (int x= 0; x<myPlayer.inventory.Count; x++)
            {
                Console.WriteLine($"{myPlayer.inventory[x].name}\t\t{myPlayer.inventory[x].cost *myLocation.markup}");
            }
            Console.WriteLine($"\n{myLocation.name}:\n{myLocation.description}\n");
            Console.WriteLine("[S]ell");
            Console.WriteLine("[B]uy");
            Console.WriteLine("[T]ravel");
            Console.WriteLine("[Q]uit");
            //bool test = true;
            //while(test)
            {
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.S:
                        SellItem();
                        break;
                    case ConsoleKey.B:
                        Buy();
                        break;
                    case ConsoleKey.T:
                        Travel();
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        //test = Quit();
                        return Quit();
                    default:
                        OptionsMenu();
                        break;
                }
            }
            return false;
        }

        public void Travel()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Where would you like to go?\n");
                for (int x = 0; x < locations.Count; x++)
                {

                    distance = myLocation.Distance(locations[Convert.ToInt32(x)]);

                    Console.WriteLine($"{x + 1}: {locations[x].name}: {distance:f2} ly");
                }
                var input = Console.ReadLine();
                if (input == "quit")
                    OptionsMenu();
                else
                {
                    myPlayer.age += myLocation.Distance(locations[Convert.ToInt32(input) - 1]);
                    myLocation = locations[Convert.ToInt32(input) - 1];
                }
                
            }
            catch(Exception)
            {
                Travel();
            }
            OptionsMenu();
        }

        public bool Buy()
        {
            
            
                //bool buy = true;
                //while (buy)
                {
                try
                { 
                    Console.Clear();
                    Console.WriteLine($"What would you like to buy\t\t Money: {myPlayer.money}\tCargo: {myPlayer.cargo}");
                    Console.WriteLine("\nItem:\t\t\tCost:\n");
                    for (int x = 0; x < items.Count; x++)
                    {
                        Console.WriteLine($"{x + 1}: {items[x].name}:\t\t{items[x].cost * myLocation.markup}");
                    }
                    Console.Write("\nSelection: ");
                    var selection = Console.ReadLine();
                    if (selection == "quit")
                    {
                        //buy = false;
                        return OptionsMenu();
                    }
                        
                    if (myPlayer.inventory.Count>9)
                        Console.WriteLine("You do not have enough space");
                    else
                    {
                        myPlayer.BuyItems(items[Convert.ToInt32(selection) - 1]);
                        myPlayer.cargo -= 1;
                    }
                        
                    Console.WriteLine();
                    
                }
                catch (Exception)
                {
                    //Console.WriteLine("Please try again.");
                    Buy();
                }
            }

            return Buy();
        }

        public bool SellItem()
        {
            
           
                //bool sell = true;

                //while (sell)
                {
                try
                { 
                    Console.Clear();
                    Console.WriteLine($"Inventory:\t\tMoney: {myPlayer.money}\n");
                    for (int x = 0; x < myPlayer.inventory.Count; x++)
                    {
                        Console.WriteLine($"{x + 1}: {myPlayer.inventory[x].name}\t\t{myPlayer.inventory[x].cost*myLocation.markup}");
                    }
                    Console.Write("What would you like to sell: \n");
                    var input = Console.ReadLine();
                    if (input == "quit")
                    {
                        //sell = OptionsMenu();
                        return OptionsMenu();
                    }
                        
                    else
                    {
                        myPlayer.inventory.RemoveAt(Convert.ToInt32(input) - 1);
                        myPlayer.money += myPlayer.inventory[Convert.ToInt32(input) - 1].cost * myLocation.markup;
                    }
                }
                catch (Exception)
                {
                    SellItem();
                }
            }
            return SellItem();
        } 

        public bool Quit()
        {
            Console.Clear();
            Console.WriteLine("Sorry to see you go...\n\n");
            return false;
        }
    }
    
}
