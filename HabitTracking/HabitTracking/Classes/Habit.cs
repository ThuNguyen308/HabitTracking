using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HabitTracking.Classes
{
    public class Habit
    {
        public int habitId { get; set; }
        public int categoryId { get; set; }
        public string habitName { get; set; }
        public DateTime habitStartDate{ get; set; }
        public DateTime habitEndDate { get; set; }
        public string habitDescription { get; set; }
        public string categoryName { get; set; }
        public string colorCode { get; set; }
        public string iconImage { get; set; }
        public int userId { get; set; }
        public List<CheckIn> checkinList { get; set; } = new List<CheckIn>();
        public void setIconImage_ColorCode()
        {
            foreach(Category c in Category.categoryList)
            {
                if(c.categoryId == categoryId)
                {
                    colorCode = c.colorCode;
                    iconImage = c.iconImage;
                    categoryName = c.categoryName;
                }
            }
        }
        
    }
}
