using KBSVertebrate.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KBSVertebrate.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}