using HabitTracking.Classes;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification.AndroidOption;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Converters;
using Plugin.LocalNotification.EventArgs;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Net.Http;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public object Schedule { get; private set; }

        public SettingPage()
        {
            InitializeComponent();
            InitInfo();
            
            
        }
        
        public async void InitInfo()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync(GlobalVariables.url + "api/User/GetUserInfo?userId=" + User.user.userId);
            User.user  = JsonConvert.DeserializeObject<User>(kq);
            txtUsername.Text = User.user.userName;
            txtEmail.Text = User.user.email;
        }
        protected override void OnAppearing()
        {
            IconImageSource = "setting_full";
            InitInfo();
        }
        protected override void OnDisappearing()
        {
            IconImageSource = "setting";
        }
        private void OnLogOutTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }
        private void OnAboutTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
        private void OnHelpTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }
        private void OnUserAccountTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserPage());
        }
        public void OnToggled(object sender, ToggledEventArgs e)
        {
            if (reminder.IsToggled)
            {
                var notification = new NotificationRequest
                {
                    BadgeNumber = 1,
                    Description = "It's time to do your task!",
                    Title = "Hey!!!!!!",
                    NotificationId = 123,
                    ReturningData = "Let's do it!",
                    Sound = "SoundNotification",
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = DateTime.Now.AddSeconds(10),
                        NotifyRepeatInterval = TimeSpan.FromDays(1),
                    }
                };
                NotificationCenter.Current.Show(notification);
            }
            
        }
    }
}