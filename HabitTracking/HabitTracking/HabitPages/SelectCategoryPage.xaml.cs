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
            lstCategory.Add(new Classes.Category { categoryId = 1, categoryName = "Art", categoryImage = "paintbrush.png", categoryColor = "Pink" });
            lstCategory.Add(new Classes.Category { categoryId = 2, categoryName = "Excercise", categoryImage = "stretching.png", categoryColor = "Blue" });
            lstCategory.Add(new Classes.Category { categoryId = 3, categoryName = "Eat clean", categoryImage = "restaurant.png", categoryColor = "Yellow" });
            lstCategory.Add(new Classes.Category { categoryId = 4, categoryName = "Love", categoryImage = "paintbrush.png", categoryColor = "Green" });
            lstCategory.Add(new Classes.Category { categoryId = 5, categoryName = "Friend", categoryImage = "paintbrush.png", categoryColor = "Pink" });
            lstCategory.Add(new Classes.Category { categoryId = 5, categoryName = "Friend", categoryImage = "paintbrush.png", categoryColor = "Pink" });
            lstCategory.Add(new Classes.Category { categoryId = 5, categoryName = "Friend", categoryImage = "paintbrush.png", categoryColor = "Pink" });
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