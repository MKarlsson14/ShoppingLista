using CommunityToolkit.Mvvm.ComponentModel;
using ShoppingLista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLista.ViewModels
{    
   public partial class ItemViewModel : BaseViewModel
    {
        [ObservableProperty] GroceryItem groceryItem;
        [ObservableProperty] bool isChecked;
        public string Name => GroceryItem.Name;

        public ItemViewModel(GroceryItem groceryItem, bool value)
        {
            GroceryItem = groceryItem;
            IsChecked = value;
        }
        public ItemViewModel()
        {
            GroceryItem = new();
        }

    }
}
