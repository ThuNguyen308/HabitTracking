using HabitTracking.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            InitHabit();
        }
        private async void InitHabit()
        {
            HttpClient http = new HttpClient();

            //Category List
            var kq = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/Category/GetCategoryList?userId=" + 1);

            Category.categoryList = JsonConvert.DeserializeObject<List<Category>>(kq);
            foreach (Category c in Category.categoryList)
            {
                c.setIconImage();
                c.setColorCode();
            }

            //Habit List
            var kq1 = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/Habit/GetHabitList?userId=" + 1);
            User.habitList = JsonConvert.DeserializeObject<List<Habit>>(kq1);
            foreach (Habit hb in User.habitList)
            {
                hb.setIconImage_ColorCode();
            }
            listHabits.ItemsSource = User.habitList;
        }

        /*private void SetColor(Category category)
        {
            ColorTypeConverter converter = new ColorTypeConverter();
            string currentColor = category.colorCode;
            colorFr.BackgroundColor = (Xamarin.Forms.Color)(converter.ConvertFromInvariantString(currentColor));
        }*/

        private void btnAddHabit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HabitPages.SelectCategoryPage());
        }
        private void btnCalendaar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.CalendarPage());

        }

        private void listHabits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Habit habitSelected = e.CurrentSelection[0] as Habit;
            Navigation.PushAsync(new Pages.HabitPage());
        }
        private void btn_calendar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CalendarPage());
        }
        private void btn_addhabit_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HabitPages.SelectCategoryPage());
        }
    }
}