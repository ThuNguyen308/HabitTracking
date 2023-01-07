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
        static float score;
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
            int processDate = (int)(DateTime.Now.Date - habit.habitStartDate).TotalDays;
            int totalDate = (int)(habit.habitEndDate - habit.habitStartDate).TotalDays;

            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
                ("http://webapiqltq.somee.com/api/Habit/GetCheckinList?habitId=" + habit.habitId);
            checkinList = JsonConvert.DeserializeObject<List<HabitHistory>>(kq);

            //**** score
            if(checkinList.Count == 0)
                score = 0;
            else
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
            scoreLbl.Text = score.ToString("#");
            await DisplayAlert(null, processDate + "; "+ checkinList.Count.ToString() + "; " + ((float)checkinList.Count / processDate)*100, "ok");

            //**** progess
            txtProgress.Text = processDate.ToString() + "/" + totalDate.ToString();
            double progress = (double)processDate / totalDate;
            //progressBar.ProgressTo(0, 500, Easing.Linear);
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
            var bestStreak = 1;
            var currentStreak = 1;
            for (int i = 0; i < list.Count-1; i++)
            {
                
                if (list[i].AddDays(1) == list[i+1])
                {
                    consecutiveDatesCounter++;
                }
                else
                {
                    if(consecutiveDatesCounter != 1 && consecutiveDatesCounter > bestStreak)
                    {
                        bestStreak = consecutiveDatesCounter;
                    }

                    consecutiveDatesCounter = 1;
                }
                if(i == list.Count-1)
                {
                    currentStreak = consecutiveDatesCounter;
                }
            }
            _ = currentStreak > 1 ? currentStreakLbl.Text = currentStreak + " DAYS" : currentStreakLbl.Text = currentStreak + " DAY";
            _ = bestStreak > 1 ? bestStreakLbl.Text = bestStreak + " DAYS" : bestStreakLbl.Text = bestStreak + " DAY";

            /*string st = "";


            for (int i = 1; i < list.Count; i++)
            {
                    st += list[i - 1].AddDays(1).ToString("MM/dd/yyyy") + " == " + list[i].ToString("MM/dd/yyyy") + "= " + (list[i - 1].AddDays(1) == list[i]).ToString() +"\n";
            }*/
           // await DisplayAlert(null, st, "ok");
            await DisplayAlert(null, bestStreak.ToString() + currentStreak.ToString(), "ok");
        }
    }
}