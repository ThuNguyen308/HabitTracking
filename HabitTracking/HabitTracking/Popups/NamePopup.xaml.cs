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
    public partial class NamePopup : Popup
    {
        public NamePopup(string lblName, string name)
        {
            InitializeComponent();
            nameLbl.Text = lblName + " Name";
            nameEnt.Text = name;
            nameEnt.Placeholder = "New " + lblName;
        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            var result = nameEnt.Text;
            Dismiss(result);
        }
    }
}