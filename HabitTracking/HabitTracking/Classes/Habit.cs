using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracking.Classes
{
    public class Habit
    {
        public int habitId { get; set; }
        public int categoryId { get; set; }
        public string habitName { get; set; }
        public DateTime startDate{ get; set; }
        public DateTime endtDate { get; set; }
        public string habitDescription { get; set; }
    }
}
