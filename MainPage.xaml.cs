using CommunityToolkit.Maui.Views;
using ShoppingLista.Models;
using ShoppingLista.ViewModels;

namespace ShoppingLista
{
    public partial class MainPage : ContentPage
    {    
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();           
            BindingContext = vm;
            vm.Title = "Mackes Shopping";
                   
        }
    }
}
