using System;
using System.Collections.Generic;
using System.Text;

namespace SoloC4
{
    class SectionState
    {
        private ConsoleColor b;
        private ConsoleColor p;
        private ConsoleColor[,] contents;
        public SectionState(int playerColorInt)
        {
            //short names used so even fill of array.
            //b = background
            //p = players color
            this.b = ConsoleColor.Yellow;
            this.p = this.PlayerColorChooser(playerColorInt);
            this.contents = new ConsoleColor[8, 8] 
            {
                {b,b,b,b,b,b,b,b},
                {b,b,p,p,p,p,b,b},
                {b,p,p,p,p,p,p,b},
                {b,p,p,p,p,p,p,b},
                {b,p,p,p,p,p,p,b},
                {b,p,p,p,p,p,p,b},
                {b,b,p,p,p,p,b,b},
                {b,b,b,b,b,b,b,b},
            };

        }

        public ConsoleColor PlayerColorChooser(int playerColorInt)
        {
            // 0 = none color (black)
            //1 = red player 
            //2 = blue player
            if (playerColorInt == 0)
            {
                return ConsoleColor.Black;

            }
            if (playerColorInt == 1)
            {
                return ConsoleColor.Red;

            }
            else
            {
                return ConsoleColor.Blue;
            }

        }
        public void ColorPicker(int row, int column)
        {
            Console.ForegroundColor= contents[row, column];
        }
    }
}
