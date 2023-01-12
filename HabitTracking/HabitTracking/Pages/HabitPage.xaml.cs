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
using Xamarin.CommunityToolkit.Effects;
using System.Net.Http;
using Newtonsoft.Json;


namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HabitPage : ContentPage
    {
        Habit _habit = new Habit();
        public HabitPage()
        {
            InitializeComponent();
        }

        public HabitPage(Habit habit)
        {
            InitializeComponent();
            Title = habit.habitName;
            _habit = habit;
            InitEditedHabit();
        }
        private void InitEditedHabit()
        {
            nameLbl.Text = _habit.habitName;
            descriptionLbl.Text = _habit.habitDescription;
            categoryNameLbl.Text = _habit.categoryName;
            categoryImg.Source = _habit.iconImage;
            startDate.Date = _habit.habitStartDate;
            endDate.Date = _habit.habitEndDate;

            ColorTypeConverter converter = new ColorTypeConverter();
            string currentColor = _habit.colorCode;
            colorBV.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            IconTintColorEffect.SetTintColor(categoryImg, (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor)));
            categoryNameLbl.TextColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
        }
        private async void Tap_OpenHabitName(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new NamePopup("Habit", _habit.habitName));
            _habit.habitName = result.ToString();
            nameLbl.Text = _habit.habitName;
        }
        private async void Tap_OpenIconCategory(object sender, EventArgs e)
        {
            Category category = new Category() { categoryId = _habit.categoryId };
            var result = await Navigation.ShowPopupAsync(new IconCategoryPopup(category));
            category = result as Category;
            _habit.categoryId = category.categoryId;
            _habit.setIconImage_ColorCode();

            categoryNameLbl.Text = _habit.categoryName;
            categoryImg.Source = _habit.iconImage;
            ColorTypeConverter converter = new ColorTypeConverter();
            string currentColor = _habit.colorCode;
            colorBV.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
            IconTintColorEffect.SetTintColor(categoryImg, (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor)));
            categoryNameLbl.TextColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
        }
        private async void Tap_OpenDescription(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new NamePopup("Description", _habit.habitDescription));
            _habit.habitDescription = result.ToString();
            descriptionLbl.Text= _habit.habitDescription;
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            _habit.habitStartDate = startDate.Date;
            _habit.habitEndDate = endDate.Date;
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(_habit);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;
            kq = await http.PostAsync(GlobalVariables.url + "api/Habit/UpdateHabit", httcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv.ToString()) > 0)
                await DisplayAlert(null, "Habit was updated", "ok");
            else
                await DisplayAlert(null, "Update failed", "ok");
            await Navigation.PushAsync(new TabbedPage1());
        }
    }
}