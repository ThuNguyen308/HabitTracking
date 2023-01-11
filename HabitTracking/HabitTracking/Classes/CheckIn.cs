using HabitTracking.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracking.Classes
{
    public class CheckIn
    {
        public int habitHistoryId { get; set; }
        public int habitId { get; set; }
        public string habitName { get; set; }
        public DateTime checkinDate { get; set; }
        public bool isChecked { get; set; }
        public int categoryId { get; set; }
        public string colorCode { get; set; }
        public string iconImage { get; set; }
    }
}
