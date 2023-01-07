using HabitTracking.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        private async void BtnSignin_Clicked(object sender, EventArgs e)
        {
            if(txtPassword.Text != txtPassword2.Text)
            {
                await DisplayAlert("Error!", "Please make sure your passwords match.", "Ok");
                return;
            }
            User user = new User { userName = txtUsername.Text, password = txtPassword.Text, email = txtEmail.Text, firstName = txtFirstName.Text, lastName = txtLastName.Text };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(user);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq = await http.PostAsync
                ("http://webapiqltq.somee.com/api/User/Signup", httcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            user = JsonConvert.DeserializeObject<User>(kqtv);
            if (user.userId > 0)
            {
                await DisplayAlert("Success", "Congratulations, your account has been successfully created", "Continue");
                await Navigation.PushAsync(new SignInPage());
            }
            else await DisplayAlert("Error", "Something wrong happened.", "Continue");
        }
        private void Tap_LogIn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.SignInPage());
        }
    }
}