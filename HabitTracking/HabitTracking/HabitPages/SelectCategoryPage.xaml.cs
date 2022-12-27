using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;

namespace HabitTracking.HabitPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCategoryPage : ContentPage
    {
        List<Classes.Category> lstCategory = new List<Classes.Category>();
        public SelectCategoryPage()
        {
            InitializeComponent();
            InitCategory();
           
        }
        private async void InitCategory()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
               ("http://10.45.95.61/webapiqltq/api/Category/GetCategoryList?userId=" + 1);

            var categoryList = JsonConvert.DeserializeObject<List<Category>>(kq);
            foreach (Category c in categoryList)
            {
                c.setIconImage(Classes.Icon.InitIcons());
                c.setColorCode(Classes.Color.InitColors());
            }
            CVCategorySelect.ItemsSource = categoryList;
        }

        private void CVCategorySelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigation.PushAsync(new HabitPages.DefineHabitPage());
        }

        private void btnCalcel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}