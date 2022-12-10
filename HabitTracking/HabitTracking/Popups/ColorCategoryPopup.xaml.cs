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
    public partial class ColorCategoryPopup : Popup
    {
        List<Classes.Color> lstColor = new List<Classes.Color>();
        public ColorCategoryPopup()
        {
            InitializeComponent();
            lstColor.Add(new Classes.Color { colorId = 1, colorCode = "#C0392B" });
            lstColor.Add(new Classes.Color { colorId =2, colorCode = "#E74C3C" });
            lstColor.Add(new Classes.Color { colorId =3, colorCode = "#9B59B6" });
            lstColor.Add(new Classes.Color { colorId =4, colorCode = "#5499C7" });
            lstColor.Add(new Classes.Color { colorId =5, colorCode = "#5DADE2" });
            lstColor.Add(new Classes.Color { colorId =6, colorCode = "#1ABC9C" });
            lstColor.Add(new Classes.Color { colorId =7, colorCode = "#45B39D" });
            lstColor.Add(new Classes.Color { colorId =8, colorCode = "#52BE80" });
            lstColor.Add(new Classes.Color { colorId =9, colorCode = "#F1C40F" });
            lstColor.Add(new Classes.Color { colorId =10, colorCode = "#F39C12" });
            lstColor.Add(new Classes.Color { colorId =11, colorCode = "#D35400" });
            lstColor.Add(new Classes.Color { colorId =12, colorCode = "#6E2C00" });
            lstColor.Add(new Classes.Color { colorId =13, colorCode = "#909497" });
            lstColor.Add(new Classes.Color { colorId =14, colorCode = "#909497" });
            lstColor.Add(new Classes.Color { colorId =15, colorCode = "#839192" });
            CVCategoryColor.ItemsSource = lstColor;
        }

        private void CVCategoryColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes.Color colorSelected = e.CurrentSelection[0] as Classes.Color;
            var result = colorSelected.colorCode.ToString();
            Dismiss(result);
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}