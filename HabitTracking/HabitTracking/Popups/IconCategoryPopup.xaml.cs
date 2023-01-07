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
    public partial class IconCategoryPopup : Popup
    {
        Category categorySelected = new Category();
        
        public IconCategoryPopup(Category category)
        {
            InitializeComponent();
            categorySelected = category;
            CVCategory.ItemsSource = Category.categoryList;
        }

        private void CVCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            categorySelected = e.CurrentSelection[0] as Category;
            Dismiss(categorySelected);
        }
        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Dismiss(categorySelected);
        }
    }
}