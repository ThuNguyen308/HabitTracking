using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;

namespace HabitTracking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouViewPage : ContentPage
    {
        List<Img> imgs = new List<Img>()
            {
                new Img(){Title = "h1", Url = "habits", quote = "HabitTracking helps you create and maintain all good habits" },
                new Img(){Title = "h1", Url = "puzzle", quote = "It's easier to achieve if your break it down into smaller goals"},
                new Img(){Title = "h1", Url = "pieChart", quote = "Create streaks of success for your habits and complete all your tasks"}
            };

        public CarouViewPage()
        {
            InitializeComponent();

            Carousel.ItemsSource = imgs;

            DoneBtn.Text = "Next";
            Device.StartTimer(TimeSpan.FromSeconds(10), (Func<bool>)(() =>
            {
                if (Carousel.Position + 1 == imgs.Count || DoneBtn.Text == "Done")
                {
                    DoneBtn.Text = "Done";

                    return false;
                }
                Carousel.Position= (Carousel.Position + 1) % imgs.Count;
                
                return true;
            }));
        }

        public void btnNext_Clicked(object sender, EventArgs e)
        {
            if (DoneBtn.Text == "Done")
            {
                Navigation.PushAsync(new Pages.SignInPage());
            }
            Carousel.Position = (Carousel.Position + 1) % imgs.Count;
            if (Carousel.Position + 1 == imgs.Count)
            {
                DoneBtn.Text = "Done";
            }
            

        }
        public void btnSkip_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.SignInPage());
        }
    }
}