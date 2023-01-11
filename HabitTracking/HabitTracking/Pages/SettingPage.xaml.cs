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

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
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
            return;
            //var notification = new NotificationRequest {
            //    BadgeNumber = 1,
            //    Description = "It's time to do your task!",
            //    Title = "Hey!!!!!!",
            //    NotificationId = 123,
            //    //NotifiTime = DateTime.Now.AddSeconds(10)
            //    //Schedule = DateTime.Now.AddSeconds(10),
            //};
            //NotificationCenter.Current.Show(notification);
            //notificationService.Show(notification);
        }
    }
}