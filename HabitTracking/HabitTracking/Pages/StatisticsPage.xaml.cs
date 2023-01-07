using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Microcharts;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        List<HabitHistory> checkinList = new List<HabitHistory>();
        public StatisticsPage()
        {
            InitializeComponent();
        }
        public StatisticsPage(Habit habit)
        {
            InitializeComponent();
            InitCheckinList(habit);
        }
        private async void InitCheckinList(Habit habit)
        {
            float score = 0;
            int processDate = (int)(DateTime.Now.Date - habit.habitStartDate).TotalDays + 1;
            if (processDate < 0) processDate = 0;
            int totalDate = (int)(habit.habitEndDate - habit.habitStartDate).TotalDays + 1;

            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/Habit/GetCheckinList?habitId=" + habit.habitId);
            checkinList = JsonConvert.DeserializeObject<List<HabitHistory>>(kq);

            //**** score
            if(checkinList.Count != 0)
                score = ((float)checkinList.Count / processDate * 100);

            ChartEntry[] entries = new[]
            {
                new ChartEntry(100)
                {
                    Color = SKColor.Parse("#fff"),
                },
                new ChartEntry(score)
                {
                    Color = SKColor.Parse("#e6005c"),
                }

            };
            chartViewPie.Chart = new RadialGaugeChart { Entries = entries };
            scoreLbl.Text = score > 0 ? score.ToString("#") : "0";

            //**** progess
            txtProgress.Text = processDate.ToString() + "/" + totalDate.ToString();
            double progress = (double)processDate / totalDate;
            progressBar.Progress = progress;
            startDateLbl.Text = habit.habitStartDate.ToString("MM/dd/yyyy");
            endDateLbl.Text = habit.habitEndDate.ToString("MM/dd/yyyy");

            //*** streak
            List<DateTime> dates = new List<DateTime>();
            foreach(HabitHistory hh in checkinList)
            {
                dates.Add(hh.checkinDate);
            }
            var list = dates.OrderBy(x => x).ToList();
            var consecutiveDatesCounter = 1;
            var length = list.Count;
            var bestStreak = length > 0 ? 1 : 0;
            var currentStreak = length > 0 ? 1 : 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (list[i].AddDays(1) == list[i+1])
                {
                    consecutiveDatesCounter++;
                    if (i == length - 2)
                        bestStreak = consecutiveDatesCounter;
                }
                else
                {
                    if(consecutiveDatesCounter != 1 && consecutiveDatesCounter > bestStreak)
                    {
                        bestStreak = consecutiveDatesCounter;
                    }
                    consecutiveDatesCounter = 1;
                }
                if (i == length -2)
                    currentStreak = consecutiveDatesCounter;
            }
            currentStreakLbl.Text = currentStreak > 1 ? currentStreak + " DAYS" : currentStreak + " DAY";
            bestStreakLbl.Text =  bestStreak > 1 ? bestStreak + " DAYS" : bestStreak + " DAY";

        }
    }
}