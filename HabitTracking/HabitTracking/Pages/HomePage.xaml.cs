using HabitTracking.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        Habit habits;
        public HomePage()
        {
            InitializeComponent();
            InitHabit();
        }
        void InitHabit()
        {
            listHabits.ItemsSource = Habit.InitHabits();

        }
    }
}