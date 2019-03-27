using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGameV2
{
    class Ship
    {
        public string name;
        public int shipCargo;

        public Ship(string name, int shipCargo)
        {
            this.name = name;
            this.shipCargo = shipCargo;
        }
    }
}
