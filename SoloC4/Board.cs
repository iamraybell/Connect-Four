using System;
using System.Collections.Generic;
using System.Text;

namespace SoloC4
{
    class Board
    {
        private int[,] contents;
        private int height;
        private int width;
        private SectionState blankSection;
        private SectionState blueSection;
        private SectionState redSection;
        private int sectionSize;


        public Board()
        {
            this.height = 8 * 6;
            this.width = 8 * 7;
            this.contents = new int[6, 7];
            this.sectionSize = 8;
            this.blankSection = new SectionState(0);
            this.redSection = new SectionState(1);
            this.blueSection = new SectionState(2);
            this.Reset();
        }

        public bool DropValid(int column)
        {
            if(column < 0||column > 6 || contents[0, column] != 0)
            {
                
                return false;
            }
            return true;
        }
        public void DropPiece(int number, int column, int row=0)
        {

            if (row <= 4 && contents[row+1, column] == 0)
            {
                DropPiece(number, column, row +1);
                return;
            }
            contents[row, column] = number;
        }
        public void Reset()
        {
            for(var rowIdx = 0; rowIdx < 6; rowIdx +=1)
            {
                for (var columnIdx = 0; columnIdx < 7; columnIdx+=1)
                {
                    this.contents[rowIdx,columnIdx] = 0;
                   

                }
            }
           
        }
        public void drawBoard()
        {
            for(var heightIdx = 0; heightIdx< height; heightIdx++)
            {

                for(var widthIdx = 0; widthIdx < width; widthIdx++)
                {
                    var sectionPicked = this.sectionPicker(heightIdx, widthIdx);
                    sectionPicked.ColorPicker(heightIdx % sectionSize, widthIdx % sectionSize);
                    Console.Write("__");
                    Console.ResetColor();
                    if(widthIdx == width-1)
                    {
                        Console.Write("\n");
                    }
                    
                }
            }
        }
        public  SectionState sectionPicker(int heightIdx, int widthIdx)
        {
            var heightFlooredBySectionSize = (int) Math.Floor(heightIdx / (double)sectionSize);
            var widthFlooredBySectionSize = (int) Math.Floor(widthIdx / (double)sectionSize);
            var intOfsectionChoosen = contents[heightFlooredBySectionSize, widthFlooredBySectionSize];
            if(intOfsectionChoosen == 0)
            {
                return blankSection;
            }
            if (intOfsectionChoosen == 1)
            {
                return redSection;
            }
            else
            {
                return blueSection;
            }
        }

    }
}
