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
using System.Net.Http;
using Newtonsoft.Json;
using HabitTracking.Classes;
using Color = HabitTracking.Classes.Color;
using System.Drawing;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        //User user = new User { userName = "Thu", password = "123" };
        Category newCategory = new Category { categoryName = "New Category", iconId = 1, colorId = 1, userId= User.user.userId};
        Category defaultCategory = new Category { categoryName = "New Category", iconId = 1, colorId = 1, userId= User.user.userId};

        Category oldCategory;
        Category _categorySelected;
        public CategoryPage()
        {
            InitializeComponent();
            InitCategory();
            InitNewCategory();
        }
        public void InitNewCategory()
        {
            defaultCategory.setIconImage();
            defaultCategory.setColorCode();
            iconImg.Source = defaultCategory.iconImage;
            SetColor(defaultCategory);
            txtCategoyName.Text = defaultCategory.categoryName;
            oldCategory = defaultCategory;
            return ;
        }
        protected override void OnAppearing()
        {
            InitCategory();
        }
        private async void InitCategory()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
                (GlobalVariables.url + "api/Category/GetCategoryList?userId=" + User.user.userId);

            Category.categoryList = JsonConvert.DeserializeObject<List<Category>>(kq);
            foreach (Category c in Category.categoryList)
            {
                var count = 0;
                c.setIconImage();
                c.setColorCode();
                foreach (Habit hb in User.habitList)
                    if (hb.categoryId == c.categoryId)
                        count++;
                c.numOfEntries = count <= 1 ? count + " Entry" : count + " Entries";
            }
            CVCategory.ItemsSource = Category.categoryList;
        }
        private void SetColor(Category category)
        {
            ColorTypeConverter converter = new ColorTypeConverter();
            string currentColor = category.colorCode;
            IconTintColorEffect.SetTintColor(iconImg, (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor)));
            IconTintColorEffect.SetTintColor(eiconImg, (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor)));
            ecolorBV.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            ecolorBV1.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            colorBV.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            colorBV1.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            btnCreateCategory.TextColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
        }

        private void CVCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            overlay.IsVisible = true;
            overlay1.IsVisible = true;
            popupEditCategory.IsVisible = true;

            _categorySelected = e.CurrentSelection[0] as Category;
            eNameCategoryLbl.Text = _categorySelected.categoryName;
            SetColor(_categorySelected);
            eiconImg.Source = _categorySelected.iconImage;
        }

        private void cmdOpenCreateCategory_Clicked(object sender, EventArgs e)
        {

            overlay.IsVisible = true;
            overlay1.IsVisible = true;
            InitNewCategory();
            _categorySelected = null;
            popupAddCategory.IsVisible = true;
        }


        private void Tap_RemovePopup(object sender, EventArgs e)
        {
            overlay.IsVisible = false;
            overlay1.IsVisible = false;
            _ = popupAddCategory.IsVisible == true ? popupAddCategory.IsVisible = false : popupEditCategory.IsVisible = false;
        }
        private async void Tap_OpenNameCategory(object sender, EventArgs e)
        {
            if (_categorySelected is null)
            {
                var result = await Navigation.ShowPopupAsync(new NamePopup("Category", null));
                newCategory.categoryName = result.ToString();
                txtCategoyName.Text = result.ToString();
            }
            else
            {
                var result = await Navigation.ShowPopupAsync(new NamePopup("Category", _categorySelected.categoryName));
                _categorySelected.categoryName = result.ToString();

                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(_categorySelected);
                StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                kq = await http.PostAsync(GlobalVariables.url + "api/Category/UpdateCategory", httcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                    await DisplayAlert("Success!", "Your category has been updated.", "Ok");
                else
                    await DisplayAlert("Error", "Oops, something went wrong.", "Ok");
                InitCategory();
            }

        }
        private async void Tap_OpenIconCategory(object sender, EventArgs e)
        {
            if (_categorySelected is null) oldCategory.iconId = newCategory.iconId;
            else oldCategory.iconId = _categorySelected.iconId;

            var result = await Navigation.ShowPopupAsync(new IconPopup(oldCategory.iconId));

            Icon  icon = result as Icon;

            if (_categorySelected is null )
            {
                newCategory.iconId = icon.iconId;
                iconImg.Source = icon.iconImage;
            }
            else
            {
                _categorySelected.iconId = icon.iconId;
                eiconImg.Source = icon.iconImage;

                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(_categorySelected);
                StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                kq = await http.PostAsync(GlobalVariables.url + "api/Category/UpdateCategory", httcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                    await DisplayAlert("Success!", "Your category has been updated.", "Ok");
                else
                    await DisplayAlert("Error", "Oops, something went wrong.", "Ok");
                InitCategory();
            }
        }
        private async void Tap_OpenColorCategory(object sender, EventArgs e)
        {
            if (_categorySelected is null) oldCategory.colorId = newCategory.colorId;
            else oldCategory.colorId = _categorySelected.colorId;

            var result = await Navigation.ShowPopupAsync(new ColorCategoryPopup(oldCategory.colorId));
            Classes.Color color = result as Classes.Color;
            
            
            if (_categorySelected is null)
            {
                newCategory.colorId = color.colorId;
                newCategory.colorCode = color.colorCode;
                SetColor(newCategory);
            }
            else
            {
                _categorySelected.colorId = color.colorId;
                _categorySelected.colorCode = color.colorCode;
                SetColor(_categorySelected);

                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(_categorySelected);
                StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                kq = await http.PostAsync(GlobalVariables.url + "api/Category/UpdateCategory", httcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (_categorySelected.colorId != oldCategory.colorId)
                {
                    if (int.Parse(kqtv.ToString()) > 0)
                        await DisplayAlert("Success!", "Your category has been updated.", "Ok");
                    else
                        await DisplayAlert("Error", "Oops, something went wrong.", "Ok");
                }
               
                InitCategory();
            }
        }
        private async void Tap_CreateCategory(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(newCategory);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;
            kq = await http.PostAsync(GlobalVariables.url + "api/Category/CreateCategory", httcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv.ToString()) > 0)
                await DisplayAlert("Success!", "Your category has been updated.", "Ok");
            else
                await DisplayAlert("Error", "Oops, something went wrong.", "Ok");
            InitCategory();
            overlay.IsVisible = false;
            overlay1.IsVisible = false;
            popupAddCategory.IsVisible = false;
        }

        private async void Tap_DeteteCategory(object sender, EventArgs e)
        {
            var delete = await DisplayAlert(null, "Delete category " + _categorySelected.categoryName + " ?", "Yes", "No");
            if(delete)
            {
                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(_categorySelected);
                StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                kq = await http.PostAsync(GlobalVariables.url + "api/Category/DeleteCategory", httpcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                {
                    await DisplayAlert(null, "Category was deleted", "ok");
                    overlay.IsVisible = false;
                    overlay1.IsVisible = false;
                    popupEditCategory.IsVisible = false;
                    InitCategory();
                }
                else
                    await DisplayAlert(null, "Delete failed", "ok");
            }
        }
    }
}