using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGameV2
{
    class Player
    {

        public int cargo;
        public string name;
        public double age;
        public double money;
        public List<Item> inventory = new List<Item>();

        public Player(int cargo, string name, int age, double money, List<Item> inventory)
        {
            this.cargo = cargo;
            this.age = age;
            this.name = name;
            this.money = money;
            this.inventory = inventory;
        }

        public void BuyItems(Item item)
        {
            
            inventory.Add(item);

            money -= item.cost;
        }

        
    }
}
