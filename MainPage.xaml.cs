using CommunityToolkit.Maui.Views;
using ShoppingLista.Models;
using ShoppingLista.ViewModels;

namespace ShoppingLista
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel vmPrivate;      

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();           
            BindingContext = vm;
            vm.Title = "Mackes Shopping";     
            vmPrivate = vm;           
        }

        private void AddItemToList_BtnClicked(object sender, EventArgs e)
        {
            this.ShowPopup(new AddItemToList(vmPrivate));
        }
    }

}
