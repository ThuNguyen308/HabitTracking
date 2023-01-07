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
        Classes.Icon oldIcon = new Classes.Icon();
        public IconPopup()
        {
            InitializeComponent();
            CVIcon.ItemsSource = Icon.InitIcons();

        }
        public IconPopup(int oldIconId)
        {
            InitializeComponent();
            CVIcon.ItemsSource = Icon.InitIcons();

            foreach (Classes.Icon ic in Classes.Icon.InitIcons())
            {
                if (oldIconId == ic.iconId)
                {
                    oldIcon = ic; break;
                }
            }
        }

        private void CVCategoryColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes.Icon iconSelected = e.CurrentSelection[0] as Icon;
            Dismiss(iconSelected);
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            
            Dismiss(oldIcon);
        }
    }
}