using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void BtnSignin_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Success","Congratulations, your account has been successfully created", "Continue");
            Navigation.PushAsync(new SignInPage());
        }
        private void Tap_LogIn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.SignInPage());
        }
    }
}