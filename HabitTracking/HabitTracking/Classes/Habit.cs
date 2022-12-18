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

        public static List<Habit> InitHabits()
        {
            List<Habit> lstHabits;
            lstHabits = new List<Habit>();

            lstHabits.Add(new Habit { habitId = 1, habitName="do housework"});
            lstHabits.Add(new Habit { habitId = 2, habitName="do homework" });
            lstHabits.Add(new Habit { habitId = 3, habitName = "workout" });

            return lstHabits;

        }
    }
}
