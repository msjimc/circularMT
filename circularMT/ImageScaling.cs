using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circularMT
{
    internal class ImageScaling
    {
        public readonly int one = 1;
        public readonly int two = 2;
        public readonly int three = 3;
        public readonly int four = 4;
        public readonly int five = 5;
        public readonly int six = 6;
        public readonly int eight = 8;
        public readonly int nine = 9;
        public readonly int ten = 10;
        public readonly int eleven = 11;
        public readonly int thirteen = 13;
        public readonly int fourteen = 14;
        public readonly int sixteen = 16;
        public readonly int nineteen = 19;
        public readonly int twenty = 20;
        public readonly int twentyTwo = 22;
        public readonly int twentyFive = 25;
        public readonly int twentyEight = 28;
        public readonly int thirty = 30;
        public readonly int thirtyTwo = 32;
        public readonly int thirtyEight = 38;
        public readonly int fourty = 40;
        public readonly int sixty = 60;
        public readonly int hundred = 100;
        public readonly float scale = 1;

        public ImageScaling(float resolution)
        {
            scale = resolution / 96;
            one = (int)((1 * scale) + 0.5f);
            two = (int)((2 * scale) + 0.5f); 
            three = (int)((3 * scale) + 0.5f);
            four = (int)((4 * scale) + 0.5f); 
            five = (int)((5 * scale) + 0.5f); 
            six = (int)((6 * scale) + 0.5f); 
            eight = (int)((8 * scale) + 0.5f); 
            nine = (int)((9 * scale) + 0.5f); 
            ten = (int)((10 * scale) + 0.5f); 
            eleven = (int)((11 * scale) + 0.5f); 
            thirteen = (int)((13 * scale) + 0.5f);
            fourteen = (int)((14 * scale) + 0.5f); 
            sixteen = (int)((16 * scale) + 0.5f); 
            nineteen = (int)((19 * scale) + 0.5f); 
            twenty = (int)((20 * scale) + 0.5f); ;
            twentyTwo = (int)((22 * scale) + 0.5f); 
            twentyFive = (int)((25 * scale) + 0.5f); 
            twentyEight = (int)((28 * scale) + 0.5f); 
            thirtyTwo = (int)((32 * scale) + 0.5f); 
            thirtyEight = (int)((38 * scale) + 0.5f); 
            thirty = (int)((30 * scale) + 0.5f); 
            fourty = (int)((40 * scale) + 0.5f); 
            sixty = (int)((60 * scale) + 0.5f); 
            hundred = (int)((100 * scale) + 0.5f); 

    }
    }
}

