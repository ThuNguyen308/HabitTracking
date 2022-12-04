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
    public partial class NameCategoryPopup : Popup
    {
        public NameCategoryPopup()
        {
            InitializeComponent();
        }

        private void btnCreateNameCategory_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}