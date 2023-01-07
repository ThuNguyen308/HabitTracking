using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HabitTracking.Classes;

namespace HabitTracking.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconPopup : Popup
    {
        public IconPopup()
        {
            InitializeComponent();
            CVIcon.ItemsSource = Icon.InitIcons();

        }
        private void CVCategoryColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes.Icon iconSelected = e.CurrentSelection[0] as Icon;
            Dismiss(iconSelected);
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Classes.Icon oldIcon = new Classes.Icon();
            oldIcon = Classes.Icon.InitIcons()[0];
            Dismiss(oldIcon);
        }
    }
}