using Newtonsoft.Json;
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

            
            //InitApp();
            
        }
        /*public async void InitApp()
        {
            *//*GlobalVariables.lstColor = new List<Classes.Color>();
            GlobalVariables.lstIcon = new List<Icon>();*/
            
            /*HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/GetColorList");
            GlobalVariables.lstColor = JsonConvert.DeserializeObject<List<Classes.Color>>(kq);


            var kq1 = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/GetIconList");
            GlobalVariables.lstIcon = JsonConvert.DeserializeObject<List<Icon>>(kq1);*//*

            //GlobalVariables.user = new User { userId = 1, userName = "Thu Nguyen" };
        }*/
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
