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
        Classes.Color oldColor = new Classes.Color();


        public ColorCategoryPopup()
        {
            InitializeComponent();
            CVCategoryColor.ItemsSource = Classes.Color.InitColors() ;

        }
        public ColorCategoryPopup(int oldColorId)
        {
            InitializeComponent();
            CVCategoryColor.ItemsSource = Classes.Color.InitColors();

            foreach (Classes.Color cl in Classes.Color.InitColors())
            {
                if (oldColorId == cl.colorId)
                {
                    oldColor = cl; break;
                }
            }

        }


        private void CVCategoryColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes.Color colorSelected = e.CurrentSelection[0] as Classes.Color;
            Dismiss(colorSelected);
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            
            Dismiss(oldColor);
        }
    }
}