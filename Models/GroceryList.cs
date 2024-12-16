namespace ShoppingLista.Models
{
    public class GroceryList
    {
        public string? NameOfList { get; set; }

        public List<GroceryItem>? Groceries { get; set; } = new();


    }
}
