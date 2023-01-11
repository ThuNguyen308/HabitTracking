using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;
using System.Collections.Generic;

[assembly: ExportFont("Roboto-Regular.ttf", Alias = "Roboto")]
[assembly: ExportFont("Roboto-Bold.ttf", Alias = "RobotoBold")]
namespace HabitTracking
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new Pages.SignInPage());
            MainPage = new NavigationPage(new CarouViewPage());
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
