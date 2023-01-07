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
            IconImageSource = "home_full";
            InitHabit();
        }
        private async void InitHabit()
        {
            HttpClient http = new HttpClient();

            //Category List
            var kq = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/Category/GetCategoryList?userId=" + User.user.userId);

            Category.categoryList = JsonConvert.DeserializeObject<List<Category>>(kq);
            foreach (Category c in Category.categoryList)
            {
                c.setIconImage();
                c.setColorCode();
            }

            //Habit List
            var kq1 = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/Habit/GetHabitList?userId=" + User.user.userId);
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
            
        }

        private async void SwipeDeleteItem_Invoked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Warning", "Do you really want to delete this habit?", "Yes", "No");
            if (answer)
            {
                SwipeItem swipeItem = (SwipeItem)sender;
                Habit product = swipeItem.CommandParameter as Habit;

                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(product);
                StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                kq = await http.PostAsync("http://webapiqltq.somee.com/api/Habit/DeleteHabit", httpcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if(int.Parse(kqtv.ToString()) > 0)
                {
                    await DisplayAlert("Habit deleted", "Habit is successfully deleted", "OK");
                    InitHabit();
                }
                else
                    await DisplayAlert("Error", "Can't delete this habit.", "OK");
            }
        }
        private async void SwipeEditItem_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            Habit habit = swipeItem.CommandParameter as Habit;

            Navigation.PushAsync(new Pages.HabitPage(habit));
        }
        
        private async void SwipeStatisticsItem_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            Habit habit = swipeItem.CommandParameter as Habit;

            Navigation.PushAsync(new Pages.StatisticsPage(habit));
        }
        private void btn_calendar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CalendarPage());
        }
        private void btn_addhabit_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HabitPages.SelectCategoryPage());
        }

        private void SearchBarHabit_TextChanged(object sender, TextChangedEventArgs e)
        {
            listHabits.ItemsSource = User.habitList.Where(habit => habit.habitName.ToLower().Contains(e.NewTextValue));
        }
    }
}