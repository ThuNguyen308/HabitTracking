using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Popups;
using HabitTracking.Classes;
using Xamarin.CommunityToolkit.Extensions;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HabitPage : ContentPage
    {
        Habit newHabit = new Habit { habitId = 1, habitName = "An com", categoryId = 1, habitDescription = "An com vui ve", startDate = new DateTime(2005, 11, 20), endtDate = new DateTime(2005, 11, 20) };
        public HabitPage()
        {
            InitializeComponent();
        }
        private async void Tap_OpenHabitName(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new NamePopup("Habit"));
            newHabit.habitName = result.ToString();
        }
        private async void Tap_OpenIconCategory(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new IconCategoryPopup());
            newHabit.categoryId = 1;
        }
        private async void Tap_OpenDescription(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new NamePopup("Description"));
            newHabit.habitDescription = result.ToString();
        }
    }
}