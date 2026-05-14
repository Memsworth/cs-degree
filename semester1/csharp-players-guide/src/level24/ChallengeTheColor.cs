using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.level24;

internal class ChallengeTheColor : IExercise
{
    public void Run()
    {
        RGBColor custom = new RGBColor(100, 50, 200);
        RGBColor black = RGBColor.Black;
    }


    class RGBColor
    {
        public byte Red { get; private set; }
        public byte Green { get; private set; }
        public byte Blue { get; private set; }

        public RGBColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public RGBColor(byte value)
        {
            Red = value;
            Green = value;
            Blue = value;
        }

        public static RGBColor White => new RGBColor(255, 255, 255);
        public static RGBColor Black => new RGBColor(0, 0, 0);
        public static RGBColor RedColor => new RGBColor(255, 0, 0);
        public static RGBColor Orange => new RGBColor(255, 165, 0);
        public static RGBColor Yellow => new RGBColor(255, 255, 0);
        public static RGBColor GreenColor => new RGBColor(0, 128, 0);
        public static RGBColor BlueColor => new RGBColor(0, 0, 255);
        public static RGBColor Purple => new RGBColor(128, 0, 128);
    }

}
