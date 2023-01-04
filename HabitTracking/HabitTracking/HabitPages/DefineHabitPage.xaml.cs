using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;

namespace HabitTracking.HabitPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefineHabitPage : ContentPage
    {
        Habit _newHabit = new Habit();
        public DefineHabitPage()
        {
            InitializeComponent();
        }
        public DefineHabitPage(Habit newHabit)
        {
            InitializeComponent();
            _newHabit = newHabit;
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            _newHabit.habitName = txtName.Text;
            _newHabit.habitDescription = txtDsc.Text;
            Navigation.PushAsync(new HabitPages.TimeHabitPage(_newHabit));
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}