using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using ShoppingLista.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace ShoppingLista.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty] ObservableCollection<ItemViewModel> groceryItemList = new();
        [ObservableProperty] string? newItem;
        [ObservableProperty] bool isChecked;
        private string jsonFileName = FileSystem.AppDataDirectory + "/ShoppingLista.json";
        public MainViewModel()
        {
            ReadFile();
        }

        public void SaveToJson()
        {
            var data = JsonSerializer.Serialize(GroceryItemList);
            File.WriteAllText(jsonFileName, data);
        }

        public void ReadFile()
        {
            if (File.Exists(jsonFileName))
            {
                var jsonString = File.ReadAllText(jsonFileName);
                var list = JsonSerializer.Deserialize
                    <ObservableCollection<ItemViewModel>>
                    (jsonString);
                if (list != null)
                {
                    GroceryItemList = list;
                }
            }
        }

        [RelayCommand]
        async Task DeleteItem()
        {
            foreach (ItemViewModel item in GroceryItemList.ToList())
            {
                if (item.IsChecked == true)
                {
                    GroceryItemList.Remove(item);
                    SaveToJson();
                    await Application.Current.MainPage.DisplayAlert(
                        "Well Done".ToUpper(),
                       "Item removed from the list!".ToUpper(),
                        "OK");
                }
            }
        }

        [RelayCommand]
        async Task Clear()
        {
            GroceryItemList.Clear();
            SaveToJson();
            await Application.Current.MainPage.DisplayAlert(
                "Well Done".ToUpper(),
               "You removed everything from your current shopping list".ToUpper(),
                "OK");
        }

        [RelayCommand]
        async Task AddToList()
        {
            if (!string.IsNullOrEmpty(NewItem))
            {
                GroceryItemList.Add(new ItemViewModel(new GroceryItem() { Name = NewItem.ToUpper() }, false));
                NewItem = String.Empty;
                SaveToJson();
                await Application.Current.MainPage.DisplayAlert(
                    "Congrats".ToUpper(),
                   "Item added to the list!".ToUpper(),
                    "OK");
            }
            else await Application.Current.MainPage.DisplayAlert(
                "Please write the name of the product".ToUpper(),
               "No item was added to the list!".ToUpper(),
                "OK");
        }

        [RelayCommand]
        async Task AddItemToList()
        {
          await Application.Current.MainPage.ShowPopupAsync(new AddItemToList(this));
        }
    }
}
