using HabitTracking.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void  loginBtn_Clicked(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://webapiqltq.somee.com/api/User/Login?username=" + txtUsername.Text + "&password=" + txtPassword.Text);
			var user = JsonConvert.DeserializeObject<User>(kq);
            if(user.userName != "" && user.userName != null)
            {
                await DisplayAlert("Success", "You are successfully logged in to your account.", "Ok");
                User.user = user;
                await Navigation.PushAsync(new TabbedPage1());

                
            }
            else 
                await DisplayAlert("Error", "Something wrong happen. Check your login credentials again.", "Ok");
        }
        private void Tap_Signup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.SignUpPage());
        }
    }
}