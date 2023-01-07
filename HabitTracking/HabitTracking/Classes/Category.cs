using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using HabitTracking.Classes;
using Newtonsoft.Json;

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
        public static List<Category> categoryList { get; set; }
        
        public void setIconImage()
        {

            foreach (Icon ic in Icon.InitIcons())
            {
                if (iconId == ic.iconId)
                {
                    iconImage = ic.iconImage;
                    break;
                }
            }
        }
        public void setColorCode()
        {

            foreach (Color c in Color.InitColors())
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
