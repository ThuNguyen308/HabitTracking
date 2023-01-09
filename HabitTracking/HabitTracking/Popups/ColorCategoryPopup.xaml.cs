using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;

namespace HabitTracking.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorCategoryPopup : Popup
    {
        
        

        public ColorCategoryPopup()
        {
            InitializeComponent();
            CVCategoryColor.ItemsSource = Classes.Color.InitColors() ;

        }
        private void CVCategoryColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes.Color colorSelected = e.CurrentSelection[0] as Classes.Color;
            Dismiss(colorSelected);
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Classes.Color oldColor = new Classes.Color();
            oldColor = Classes.Color.InitColors()[0];
            Dismiss(oldColor);
        }
    }
}