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
                await DisplayAlert("success", "you log in successfully", "ok");
                User.user = user;
                await Navigation.PushAsync(new TabbedPage1());
            }
            else 
                await DisplayAlert("error", "Something wrong happen", "ok");
        }
        private void Tap_Signup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.SignUpPage());
        }
    }
}