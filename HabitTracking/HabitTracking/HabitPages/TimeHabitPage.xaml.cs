﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracking.HabitPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeHabitPage : ContentPage
    {
        public TimeHabitPage()
        {
            InitializeComponent();
            startDatePkr.MinimumDate = DateTime.Now.Date;
            endDatePkr.MinimumDate = DateTime.Now.Date;
            endDatePkr.Date = endDatePkr.Date.AddDays(7).Date;
        }

        private void btnSaveHabit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedPage1());
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}