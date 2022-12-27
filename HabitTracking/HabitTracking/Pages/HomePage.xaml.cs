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

        private void btnAddHabit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HabitPages.SelectCategoryPage());
        }
        private void btnCalendaar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.CalendarPage());

        }

        private void listHabits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Habit habitSelected = e.CurrentSelection[0] as Habit;
            Navigation.PushAsync(new Pages.HabitPage());
        }
    }
}