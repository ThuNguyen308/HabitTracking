﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;
using System.Collections.Generic;

namespace HabitTracking
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Pages.SignInPage());

            InitApp();
            
        }
        public async void InitApp()
        {
            User user = new User { userName = "Thu", password = "123" };
            
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
