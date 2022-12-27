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

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        bool isCreate = true;
        public Category newCategory = new Category { categoryName = "New Category", iconId = 1, colorId = 1, userId=1};
        public CategoryPage()
        {
            InitializeComponent();
            InitCategory();
            InitNewCategory();
            
        }
        public void InitNewCategory()
        {
            newCategory.setIconImage(Classes.Icon.InitIcons());
            newCategory.setColorCode(Classes.Color.InitColors());
            iconImg.Source = newCategory.iconImage;
            SetColor(newCategory);
        }
        private async void InitCategory()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
                ("http://10.45.95.61/webapiqltq/api/Category/GetCategoryList?userId=" + 1);
        
            var categoryList = JsonConvert.DeserializeObject<List<Category>>(kq);
            foreach (Category c in categoryList)
            {
                c.setIconImage(Classes.Icon.InitIcons());
                c.setColorCode(Classes.Color.InitColors());
            }
            CVCategory.ItemsSource = categoryList;
        }
        private void SetColor(Category category)
        {
            ColorTypeConverter converter = new ColorTypeConverter();
            string currentColor = category.colorCode;
            IconTintColorEffect.SetTintColor(iconImg, (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor)));
            IconTintColorEffect.SetTintColor(eiconImg, (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor)));
            colorFr.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            ecolorFr.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            ecolorBV.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            colorBV.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            btnCreateCategory.TextColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
        }

        private void CVCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            overlay.IsVisible = true;
            popupEditCategory.IsVisible = true;

            Category categorySelected = e.CurrentSelection[0] as Category;
            eNameCategoryLbl.Text = categorySelected.categoryName;
            SetColor(categorySelected);
            eiconImg.Source = categorySelected.iconImage;
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
            Icon icon = result as Icon;
            iconImg.Source = icon.iconImage;
            newCategory.iconId = icon.iconId;
        }
        private async void Tap_OpenColorCategory(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new ColorCategoryPopup());
            Classes.Color color = result as Classes.Color;
            newCategory.colorId = color.colorId;
            newCategory.colorCode = color.colorCode;
            SetColor(newCategory);
        }
        private async void Tap_CreateCategory(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(newCategory);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;
            kq = await http.PostAsync("http://10.45.95.61/webapiqltq/api/Category/CreateCategory", httcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            if(int.Parse(kqtv.ToString()) > 0)
                DisplayAlert("Thông báo", "Cập nhật dữ liệu thành công", "ok");
            else
                DisplayAlert("Thông báo", "Cập nhật dữ liệu tb", "ok");
            InitCategory();
            overlay.IsVisible = false;
            popupAddCategory.IsVisible = false;
        }

        private async void Tap_DeteteCategory(object sender, EventArgs e)
        {
            _= DisplayAlert(null, "Delete category", "Yes", "No");
        }
    }
}