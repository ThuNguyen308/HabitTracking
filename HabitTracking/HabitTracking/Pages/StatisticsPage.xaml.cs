using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Microcharts;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        private readonly ChartEntry[] entries = new[]
        {
            new ChartEntry(100)
            {
                Color = SKColor.Parse("#fff"),
            },
            new ChartEntry(50)
            {
                Color = SKColor.Parse("#e6005c"),
            }
        };
        public StatisticsPage()
        {
            InitializeComponent();
            chartViewPie.Chart = new RadialGaugeChart { Entries = entries};
            progressBar.ProgressTo(0.75, 500, Easing.Linear);
            int date = 14;
            int totalDate = 47;
            txtProgress.Text = date.ToString() + "/" + totalDate.ToString();
        }

    }
}