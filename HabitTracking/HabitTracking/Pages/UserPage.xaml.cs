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
using static System.Net.Mime.MediaTypeNames;

namespace HabitTracking.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            InitInfo();
        }
        public void InitInfo()
        {
            txtFirstName.Text = User.user.firstName;
            txtLastName.Text = User.user.lastName;
            txtEmail.Text = User.user.email;
            txtUsername.Text = User.user.userName;
            txtPassword.Text = User.user.password;
        }
        public async void btnUpdateUser_Clicked(object sender, EventArgs e)
        {
            User.user.firstName = txtFirstName.Text;
            User.user.lastName = txtLastName.Text;
            User.user.email = txtEmail.Text ;
            User.user.userName = txtUsername.Text ;
            User.user.password = txtPassword.Text ;
            await DisplayAlert(null, txtEmail.Text.ToString() + " " + txtFirstName.Text + " " + txtLastName.Text + " " + txtPassword.Text + " " + txtUsername.Text, "ok");
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(User.user);
            StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;
            kq = await http.PostAsync(GlobalVariables.url + "api/User/UpdateUserInfo", httpcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv.ToString()) > 0)
            {
                await DisplayAlert(null, "Update Success", "ok");
                txtFirstName.Text = User.user.firstName;
                txtLastName.Text = User.user.lastName;
                txtEmail.Text = User.user.email;
                txtUsername.Text = User.user.userName;
                txtPassword.Text = User.user.password;
            }
            else
                await DisplayAlert(null, "Delete failed", "ok");
        }
            
        
    }
}