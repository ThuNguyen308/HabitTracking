using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracking.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconCategoryPopup : Popup
    {
        List<Classes.Icon> lstIcon = new List<Classes.Icon>();
        public IconCategoryPopup()
        {
            InitializeComponent();
            lstIcon.Add(new Classes.Icon { iconId = 1, iconImage = "paintbrush.png" });
            lstIcon.Add(new Classes.Icon { iconId = 2, iconImage = "restaurant.png" });
            lstIcon.Add(new Classes.Icon { iconId = 3, iconImage = "paintbrush.png" });
            lstIcon.Add(new Classes.Icon { iconId = 4, iconImage = "restaurant.png" });
            lstIcon.Add(new Classes.Icon { iconId = 5, iconImage = "paintbrush.png" });
            lstIcon.Add(new Classes.Icon { iconId = 6, iconImage = "stretching.png" });
            lstIcon.Add(new Classes.Icon { iconId = 7, iconImage = "paintbrush.png" });
            lstIcon.Add(new Classes.Icon { iconId = 8, iconImage = "stretching.png" });
            lstIcon.Add(new Classes.Icon { iconId = 9, iconImage = "paintbrush.png" });
            lstIcon.Add(new Classes.Icon { iconId = 10, iconImage = "paintbrush.png" });
            lstIcon.Add(new Classes.Icon { iconId = 11, iconImage = "paintbrush.png" });
            lstIcon.Add(new Classes.Icon { iconId = 12, iconImage = "paintbrush.png" });
            CVCategoryIcon.ItemsSource = lstIcon;
        }

        private void CVCategoryIcon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Classes.Icon imageSelected = e.CurrentSelection[0] as Classes.Icon;
            string result = imageSelected.iconImage as String;
            Dismiss(result);
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}