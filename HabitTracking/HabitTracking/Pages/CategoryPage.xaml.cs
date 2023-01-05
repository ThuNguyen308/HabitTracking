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
        User user = new User { userName = "Thu", password = "123" };
        Category newCategory = new Category { categoryName = "New Category", iconId = 1, colorId = 1, userId=1};
        Category _categorySelected;
        public CategoryPage()
        {
            InitializeComponent();
            InitCategory();
            InitNewCategory();
            
        }
        public void InitNewCategory()
        {
            newCategory.setIconImage();
            newCategory.setColorCode();
            iconImg.Source = newCategory.iconImage;
            SetColor(newCategory);
        }
        private async void InitCategory()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/Category/GetCategoryList?userId=" + 1);

            Category.categoryList = JsonConvert.DeserializeObject<List<Category>>(kq);
            foreach (Category c in Category.categoryList)
            {
                c.setIconImage();
                c.setColorCode();
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
            popupEditCategory.IsVisible = true;

            _categorySelected = e.CurrentSelection[0] as Category;
            eNameCategoryLbl.Text = _categorySelected.categoryName;
            SetColor(_categorySelected);
            eiconImg.Source = _categorySelected.iconImage;
        }

        private void cmdOpenCreateCategory_Clicked(object sender, EventArgs e)
        {
            overlay.IsVisible = true;
            popupAddCategory.IsVisible = true;
            _categorySelected = null;
        }
        

        private void Tap_RemovePopup(object sender, EventArgs e)
        {
            overlay.IsVisible = false;
            _ = popupAddCategory.IsVisible == true ? popupAddCategory.IsVisible = false : popupEditCategory.IsVisible = false;
        }
        private async void Tap_OpenNameCategory(object sender, EventArgs e)
        {
            if (_categorySelected is null)
            {
                var result = await Navigation.ShowPopupAsync(new NamePopup("Category", null));
                newCategory.categoryName = result.ToString();
            }
            else
            {
                var result = await Navigation.ShowPopupAsync(new NamePopup("Category", _categorySelected.categoryName));
                _categorySelected.categoryName = result.ToString();

                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(_categorySelected);
                StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                kq = await http.PostAsync("http://webapiqltq.somee.com/api/Category/UpdateCategory", httcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                    await DisplayAlert("Thông báo", "Cập nhật dữ liệu thành công", "ok");
                else
                    await DisplayAlert("Thông báo", "Cập nhật dữ liệu thất bại", "ok");
                InitCategory();
            }

        }
        private async void Tap_OpenIconCategory(object sender, EventArgs e)
        {
            Category category = new Category() { categoryId = _categorySelected.categoryId };
            var result = await Navigation.ShowPopupAsync(new IconCategoryPopup(category));
            Icon icon = result as Icon;
            if (_categorySelected is null)
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
                kq = await http.PostAsync("http://webapiqltq.somee.com/api/Category/UpdateCategory", httcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                    DisplayAlert("Thông báo", "Cập nhật dữ liệu thành công", "ok");
                else
                    DisplayAlert("Thông báo", "Cập nhật dữ liệu thất bại", "ok");
                InitCategory();
            }
        }
        private async void Tap_OpenColorCategory(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new ColorCategoryPopup());
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
                kq = await http.PostAsync("http://webapiqltq.somee.com/api/Category/UpdateCategory", httcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                    DisplayAlert("Thông báo", "Cập nhật dữ liệu thành công", "ok");
                else
                    DisplayAlert("Thông báo", "Cập nhật dữ liệu thất bại", "ok");
                InitCategory();
            }
        }
        private async void Tap_CreateCategory(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(newCategory);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;
            kq = await http.PostAsync("http://webapiqltq.somee.com/api/Category/CreateCategory", httcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            if(int.Parse(kqtv.ToString()) > 0)
                DisplayAlert("Thông báo", "Thêm dữ liệu thành công", "ok");
            else
                DisplayAlert("Thông báo", "Thêm dữ liệu tb", "ok");
            InitCategory();
            overlay.IsVisible = false;
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
                kq = await http.PostAsync("http://webapiqltq.somee.com/api/Category/DeleteCategory", httpcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                {
                    await DisplayAlert("Thông báo", "Xóa dữ liệu thành công", "ok");
                    InitCategory();
                }
                else
                    await DisplayAlert("Thông báo", "Xóa dữ liệu Lỗi", "ok");
            }
        }
    }
}