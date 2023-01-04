﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;
using System.Net.Http;
using Newtonsoft.Json;

namespace HabitTracking.HabitPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeHabitPage : ContentPage
    {
        Habit _newhabit = new Habit();
        public TimeHabitPage()
        {
            InitializeComponent();
        }
        public TimeHabitPage(Habit newHabit)
        {
            InitializeComponent();
            _newhabit = newHabit;
            startDatePkr.MinimumDate = DateTime.Now.Date;
            endDatePkr.MinimumDate = DateTime.Now.Date;
            endDatePkr.Date = endDatePkr.Date.AddDays(7).Date;
        }

        private async void btnSaveHabit_Clicked(object sender, EventArgs e)
        {
            _newhabit.startDate = startDatePkr.Date;
            _newhabit.endtDate = endDatePkr.Date;

            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(_newhabit);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;
            kq = await http.PostAsync("http://webapiqltq.somee.com/api/Habit/CreateHabit", httcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv.ToString()) > 0)
                await DisplayAlert("Success", "Add new habit successfully", "ok");
            else
                await DisplayAlert("Error", "Can't add new habit.", "ok");
            Navigation.PushAsync(new TabbedPage1());
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}