using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;

namespace HabitTracking.HabitPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCategoryPage : ContentPage
    {
        Habit newHabit = new Habit() { userId = 1};
        public SelectCategoryPage()
        {
            InitializeComponent();
            CVCategorySelect.ItemsSource = Category.categoryList;
        }

        private void CVCategorySelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category selectedCategory = e.CurrentSelection[0] as Category;
            newHabit.categoryId = selectedCategory.categoryId;
            Navigation.PushAsync(new HabitPages.DefineHabitPage(newHabit));
        }

        private void btnCalcel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}