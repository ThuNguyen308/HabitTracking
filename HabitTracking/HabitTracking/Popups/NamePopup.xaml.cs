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
        public NamePopup(string name)
        {
            InitializeComponent();
            nameEnt.Text = name;
        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            var result = nameEnt.Text;
            Dismiss(result);
        }
    }
}