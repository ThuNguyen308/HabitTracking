using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;
using HabitTracking.Popups;
using Xamarin.CommunityToolkit.Extensions;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        List<Category> lstCategory = new List<Category>();
        public CategoryPage()
        {
            InitializeComponent();

            lstCategory.Add(new Category { categoryId = 1, categoryName = "Art", categoryImage = "paintbrush.png", categoryColor = "Pink" });
            lstCategory.Add(new Category { categoryId = 2, categoryName = "Excercise", categoryImage = "stretching.png", categoryColor = "Blue" });
            lstCategory.Add(new Category { categoryId = 3, categoryName = "Eat clean", categoryImage = "restaurant.png", categoryColor = "Yellow" });
            lstCategory.Add(new Category { categoryId = 4, categoryName = "Love", categoryImage = "paintbrush.png", categoryColor = "Green" });
            lstCategory.Add(new Category { categoryId = 5, categoryName = "Friend", categoryImage = "paintbrush.png", categoryColor = "Pink" });
            CVCategory.ItemsSource = lstCategory;
        }

        private void CVCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmdOpenCreateCategory_Clicked(object sender, EventArgs e)
        {
            overlay.IsVisible = true;
            popupAddCategory.IsVisible = true;
        }
        

        private void Tap_RemoveAdd(object sender, EventArgs e)
        {
            overlay.IsVisible = false;
            popupAddCategory.IsVisible = false;
        }
        private void Tap_OpenNameCategory(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new NameCategoryPopup());
        }
        private void Tap_OpenIconCategory(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new IconCategoryPopup());
        }
        private void Tap_OpenColorCategory(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new ColorCategoryPopup());
        }
        private void Tap_CreateCategory(object sender, EventArgs e)
        {
            overlay.IsVisible = false;
            popupAddCategory.IsVisible = false;
        }
    }
}