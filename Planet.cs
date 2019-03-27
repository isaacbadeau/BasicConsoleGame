using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGameV2
{
    class Planet
    {
        
        public string name;
        public string description;
        public double markup;
        double xPos;
        double yPos;

        public Planet(string name, string description, double xPos, double yPos, double markup)
        {
            this.name = name;
            this.description = description;
            
            this.xPos = xPos;
            this.yPos = yPos;
            this.markup = markup;
        }

        

        public double Distance(Planet destination)
        {
            var left = Math.Pow(this.xPos - destination.xPos, 2);
            var right = Math.Pow(this.yPos - destination.yPos, 2);
            return Math.Sqrt(right + left);
        }



            
    }
}
