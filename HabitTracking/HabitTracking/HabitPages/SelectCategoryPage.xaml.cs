using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracking.HabitPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCategoryPage : ContentPage
    {
        List<Classes.Category> lstCategory = new List<Classes.Category>();
        public SelectCategoryPage()
        {
            InitializeComponent();
            CVCategorySelect.ItemsSource = lstCategory;
        }

        private void CVCategorySelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigation.PushAsync(new HabitPages.DefineHabitPage());
        }

        private void btnCalcel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}