using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace SeeboatApp
{
    class ColorChooser
    {
        public static float min = 0;
        public static float max = 400;
        public static SkiaSharp.SKColor ChooseEntryColor(float value)
        {
            float ColorValue = normf(value, max, min);
            float red = 255 - ColorValue;
            float green = ColorValue;
            return new SKColor((byte)red, (byte)green, 0);

        }

        public static float normf(float x, float low, float high)
        {
            float y = (x - low) * 255 / (high - low); // (temp distance from lowest temp)/(temp range)* 255 (when rearranged)==>rescaling
                                                      //don't go above upper limit
            if (y > 255)
            {
                y = 255;
            }
            //don't go below lower limit
            if (y < 0)
            {
                y = 0;
            }

            //LOOK AT THIS
            //FLIP IT, since 0 and 255 are reversed for us we think?
            //y = 255-y;

            return y; //this is a value from 0 to 255

        }


    }
}
