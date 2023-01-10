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
    public partial class AllHabitPage : ContentPage
    {
        public AllHabitPage()
        {
            InitializeComponent();
            InitHabit();
        }
        public async void InitHabit()
        {
            HttpClient http = new HttpClient();

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
        public async void OnTapStatistic(object sender, EventArgs e)
        {
            Image stackLayout = (Image)sender;
            Habit habit = stackLayout.BindingContext as Habit;


            await Navigation.PushAsync(new Pages.StatisticsPage(habit));
        }
        public async void OnTapEdit(object sender, EventArgs e)
        {
            Image stackLayout = (Image)sender;
            Habit habit = stackLayout.BindingContext as Habit;

            Navigation.PushAsync(new Pages.HabitPage(habit));

        }
        public async void OnTapDelete(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Warning", "Do you really want to delete this habit?", "Yes", "No");
            if (answer)
            {
                Image stackLayout = (Image)sender;
                Habit habit = stackLayout.BindingContext as Habit;

                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(habit);
                StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                kq = await http.PostAsync("http://webapiqltq.somee.com/api/Habit/DeleteHabit", httpcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                {
                    await DisplayAlert("Habit deleted", "Habit is successfully deleted", "OK");
                    InitHabit();
                }
                else
                    await DisplayAlert("Error", "Can't delete this habit.", "OK");
            }
        }
    }
}