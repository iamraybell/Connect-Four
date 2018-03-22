using System;
using System.Collections.Generic;
using System.Text;

namespace SoloC4
{
    class Player
    {
        private string name;
        private int number;


        public Player(string name, int number)
        {
            this.name = name;
            this.number = number;
        }
        public String GetName()
        {
            return name;
        }
        public int GetNum()
        {
            return number;
        }

        
    }
}
