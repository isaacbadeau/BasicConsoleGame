using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGameV2
{
    public class Item
    {
        public string name;
        public double cost;
        

        public Item(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}
