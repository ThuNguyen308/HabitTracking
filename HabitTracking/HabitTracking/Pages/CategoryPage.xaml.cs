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
using Xamarin.CommunityToolkit.Effects;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        Category newCategory = new Category { categoryName = "New Category", categoryImage = "categoryIcon.png", categoryColor = "Yellow" };
        public CategoryPage()
        {
            InitializeComponent();
            InitCategorys();
            iconImg.Source = newCategory.categoryImage;
            setColor(newCategory);
            
        }
        private void InitCategorys()
        {
            List<Category> lstCategory = new List<Category>();
            lstCategory.Add(new Category { categoryId = 1, categoryName = "Art", categoryImage = "paintbrush.png", categoryColor = "#C0392B" });
            lstCategory.Add(new Category { categoryId = 2, categoryName = "Excercise", categoryImage = "stretching.png", categoryColor = "#E74C3C" });
            lstCategory.Add(new Category { categoryId = 3, categoryName = "Eat clean", categoryImage = "restaurant.png", categoryColor = "#9B59B6" });
            lstCategory.Add(new Category { categoryId = 4, categoryName = "Love", categoryImage = "paintbrush.png", categoryColor = "#5DADE2" });
            lstCategory.Add(new Category { categoryId = 5, categoryName = "Friend", categoryImage = "paintbrush.png", categoryColor = "#52BE80" });
            CVCategory.ItemsSource = lstCategory;
        }
        private void setColor(Category category)
        {
            ColorTypeConverter converter = new ColorTypeConverter();
            string currentColor = category.categoryColor;
            IconTintColorEffect.SetTintColor(iconImg, (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor)));
            colorFr.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            colorBV.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            btnCreateCategory.TextColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
        }

        private void CVCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            overlay.IsVisible = true;
            popupEditCategory.IsVisible = true;

            Classes.Category categorySelected = e.CurrentSelection[0] as Classes.Category;
            eNameCategoryLbl.Text = categorySelected.categoryName;
            setColor(categorySelected);
            eiconImg.Source = categorySelected.categoryImage;
        }

        private void cmdOpenCreateCategory_Clicked(object sender, EventArgs e)
        {
            overlay.IsVisible = true;
            popupAddCategory.IsVisible = true;
        }
        

        private void Tap_RemovePopup(object sender, EventArgs e)
        {
            overlay.IsVisible = false;
            _ = popupAddCategory.IsVisible == true ? popupAddCategory.IsVisible = false : popupEditCategory.IsVisible = false;
        }
        private async void Tap_OpenNameCategory(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new NamePopup("Category"));
            newCategory.categoryName = result.ToString();
        }
        private async void Tap_OpenIconCategory(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new IconCategoryPopup());
            newCategory.categoryImage = result.ToString();
            iconImg.Source = result.ToString();
        }
        private async void Tap_OpenColorCategory(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new ColorCategoryPopup());
            newCategory.categoryColor = result.ToString();
            iconImg.Source = newCategory.categoryImage;
            setColor(newCategory);
        }
        private async void Tap_CreateCategory(object sender, EventArgs e)
        {
            await DisplayAlert("Thong bao", $"Ten {newCategory.categoryName}, color {newCategory.categoryColor}, icon {newCategory.categoryImage}", "ok");
            /*overlay.IsVisible = false;
            popupAddCategory.IsVisible = false;*/
        }

        private async void Tap_DeteteCategory(object sender, EventArgs e)
        {
            _= DisplayAlert(null, "Delete category", "Yes", "No");
        }
    }
}