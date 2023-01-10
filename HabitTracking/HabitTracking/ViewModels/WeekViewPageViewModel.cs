using HabitTracking.Classes;
using HabitTracking.Pages;
using SampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Text;

using Xamarin.Plugin.Calendar.Models;
using Xamarin.Plugin.Calendar.Enums;
using Xamarin.Forms;
using SampleApp.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace HabitTracking.ViewModels
{
    public class WeekViewPageViewModel : BasePageViewModel
    {
        public ICommand TodayCommand => new Command(() =>
        {
            ShownDate = DateTime.Today;
            SelectedDate = DateTime.Today;
        });

        public ICommand EventSelectedCommand => new Command(async (item) => await ExecuteEventSelectedCommand(item));

        public WeekViewPageViewModel() : base()
        {
            // testing all kinds of adding events
            // when initializing collection
            Events = new EventCollection();
            List<DateTime> dateList = new List<DateTime>();
            foreach (Habit hb in User.habitList)
            {
                dateList.Add(hb.habitStartDate);
                dateList.Add(hb.habitEndDate);
            }
            DateTime smallestDate = dateList.Min(p => p);
            DateTime biggestDate = dateList.Max(p => p);
            int length = (int)(biggestDate - smallestDate).TotalDays + 1;

            for (int i = 0; i < length; i++)
            {
                Events.Add(smallestDate.AddDays(i), GenerateHabitListbyDate(smallestDate.AddDays(i)));
            }
        }
        private List<CheckIn> GenerateHabitListbyDate(DateTime date)
        {
            List<CheckIn> habits = new List<CheckIn>();
            foreach (Habit habit in User.habitList)
            {
                if (date >= habit.habitStartDate && date <= habit.habitEndDate)
                {
                    foreach (CheckIn ci in habit.checkinList)
                    {
                        if (ci.checkinDate == date)
                        {
                            habits.Add(ci);
                            break;
                        }
                    }
                }
            }
            return habits;
        }

        public EventCollection Events { get; set; }

        private int _day = DateTime.Today.Day;

        public int Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }

        private int _month = DateTime.Today.Month;

        public int Month
        {
            get => _month;
            set => SetProperty(ref _month, value);
        }

        private int _year = DateTime.Today.Year;

        public int Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }

        private DateTime _shownDate = DateTime.Today;

        public DateTime ShownDate
        {
            get => _shownDate;
            set => SetProperty(ref _shownDate, value);
        }

        private WeekLayout _calendarLayout = WeekLayout.Week;

        public WeekLayout CalendarLayout
        {
            get => _calendarLayout;
            set => SetProperty(ref _calendarLayout, value);
        }

        private DateTime? _selectedDate = DateTime.Today;

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        private DateTime _minimumDate = DateTime.Today.AddYears(-2).AddMonths(-5);

        public DateTime MinimumDate
        {
            get => _minimumDate;
            set => SetProperty(ref _minimumDate, value);
        }

        private DateTime _maximumDate = DateTime.Today.AddMonths(5);

        public DateTime MaximumDate
        {
            get => _maximumDate;
            set => SetProperty(ref _maximumDate, value);
        }

        private async Task ExecuteEventSelectedCommand(object item)
        {
            
            if (item is CheckIn eventModel)
            {
                await App.Current.MainPage.DisplayAlert(eventModel.habitName.ToString(), SelectedDate.ToString(), "Ok");
                HttpClient http = new HttpClient();
                eventModel.checkinDate = (DateTime)SelectedDate;
                string jsonlh = JsonConvert.SerializeObject(eventModel);
                StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                if (eventModel.isChecked == false)
                {
                    kq = await http.PostAsync("http://webapiqltq.somee.com/api/Habit/Checkin", httcontent);
                    var kqtv = await kq.Content.ReadAsStringAsync();
                    if (int.Parse(kqtv.ToString()) > 0)
                    {
                        await App.Current.MainPage.DisplayAlert(null, "checked", "ok");
                        eventModel.isChecked = true;
                    }
                    else
                        await App.Current.MainPage.DisplayAlert(null, "check fail", "ok");
                }
                else
                {
                    kq = await http.PostAsync("http://webapiqltq.somee.com/api/Habit/DeleteCheckin", httcontent);
                    var kqtv = await kq.Content.ReadAsStringAsync();
                    if (int.Parse(kqtv.ToString()) > 0)
                    {
                        await App.Current.MainPage.DisplayAlert(null, "Unchecked", "ok");
                        eventModel.isChecked = false;
                    }
                    else
                        await App.Current.MainPage.DisplayAlert(null, "uncheck fail", "ok");
                }
            }
        }
    }

}
