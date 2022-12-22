using System;
using System.Collections.Generic;
using System.Text;
using HabitTracking.Classes;

namespace HabitTracking.Classes
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int colorId { get; set; }
        public int iconId { get; set; }
        public int userId { get; set; }
        public string colorCode { get; set; }
        public string iconImage { get; set; }
        public void setIconImage(List<Icon> lstIcon)
        {

            foreach (Icon ic in lstIcon)
            {
                if (iconId == ic.iconId)
                {
                    iconImage = ic.iconImage;
                    break;
                }
            }
        }
        public void setColorCode(List<Color> lstColor)
        {

            foreach (Color c in lstColor)
            {
                if (colorId == c.colorId)
                {
                    colorCode = c.colorCode;
                    break;
                }
            }
        }
    }
}
