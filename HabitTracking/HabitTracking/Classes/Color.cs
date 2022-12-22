using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracking.Classes
{
    public class Color
    {
        public int colorId { get; set; }
        public string colorCode { get; set; }
        public static List<Color> InitColors()
        {
            List<Color> lstColors;
            lstColors = new List<Color>();

            lstColors.Add(new Classes.Color { colorId = 1, colorCode = "#e60000" });
            lstColors.Add(new Classes.Color { colorId = 2, colorCode = "#e6005c" });
            lstColors.Add(new Classes.Color { colorId = 3, colorCode = "#e60073" });
            lstColors.Add(new Classes.Color { colorId = 4, colorCode = "#cc0099" });
            lstColors.Add(new Classes.Color { colorId = 5, colorCode = "#ac00e6" });
            lstColors.Add(new Classes.Color { colorId = 6, colorCode = "#7300e6" });
            lstColors.Add(new Classes.Color { colorId = 7, colorCode = "#0066ff" });
            lstColors.Add(new Classes.Color { colorId = 8, colorCode = "#009999" });
            lstColors.Add(new Classes.Color { colorId = 9, colorCode = "#00b386" });
            lstColors.Add(new Classes.Color { colorId = 10, colorCode = "#2d862d" });
            lstColors.Add(new Classes.Color { colorId = 11, colorCode = "#00cc00" });
            lstColors.Add(new Classes.Color { colorId = 12, colorCode = " #73e600" });
            lstColors.Add(new Classes.Color { colorId = 13, colorCode = "#999900" });
            lstColors.Add(new Classes.Color { colorId = 14, colorCode = "#ff9900" });
            lstColors.Add(new Classes.Color { colorId = 15, colorCode = "#ff8000" });
            lstColors.Add(new Classes.Color { colorId = 16, colorCode = "#cc4400" });
            lstColors.Add(new Classes.Color { colorId = 17, colorCode = "#ff3300" });

            return lstColors;
        }
    }
}
