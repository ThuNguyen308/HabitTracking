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

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public object Schedule { get; private set; }

        public SettingPage()
        {
            InitializeComponent();
            if(User.user.userId > 0)
            {
                txtUsername.Text = User.user.userName;
                txtEmail.Text = User.user.email;
            }
            else
            {
                txtUsername.Text = "Anonymous";
                txtEmail.Text = "anonymous@gmail.com";
            }
            
        }
        protected override void OnAppearing()
        {
            IconImageSource = "setting_full";
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