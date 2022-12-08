using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HabitTracking.Classes;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.Extensions;

namespace HabitTracking
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void AddCategory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.CategoryPage());
        }

        private void AddN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HabitPages.SelectCategoryPage());
        }
    }
}
