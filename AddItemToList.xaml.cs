using CommunityToolkit.Maui.Views;
using ShoppingLista.ViewModels;

namespace ShoppingLista;

public partial class AddItemToList : Popup
{
	public AddItemToList(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		this.Close();
    }
}