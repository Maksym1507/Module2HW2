using System;
using System.Text;

namespace Practice_6
{
    public class ShoppingCartService
    {
        private readonly Catalog _products;

        public ShoppingCartService()
        {
            _products = Catalog.Instance;
            StringBuilderSelectedProducts = new StringBuilder();
        }

        public static StringBuilder StringBuilderSelectedProducts { get; set; }

        public void AddToShoppingCart(string[] selectedProducts)
        {
            bool checkAvailability;
            for (int i = 0; i < selectedProducts.Length; i++)
            {
                checkAvailability = false;
                for (int j = 0; j < _products.ListOfProducts.Length; j++)
                {
                    if (selectedProducts[i] == _products.ListOfProducts[j])
                    {
                        StringBuilderSelectedProducts.Append($"{selectedProducts[i]},");
                        checkAvailability = true;
                    }
                }

                if (!checkAvailability)
                {
                    NotificationService.ShowMessage("This product(-s) is/are absent in catalog\n");
                    ShoppingCart.SelectedProducts = null;
                    return;
                }
            }

            ShoppingCart.SelectedProducts = StringBuilderSelectedProducts.ToString().TrimEnd(',').Split(",");

            if (!CheckingSelectedProducts(out string message))
            {
                NotificationService.ShowMessage(message);
                ShoppingCart.SelectedProducts = null;
                return;
            }

            NotificationService.ShowMessage("Product(-s) was/were added to shopping cart\n");
        }

        public static void ShowShoppingCart()
        {
            if (!CheckingSelectedProducts(out string message))
            {
                NotificationService.ShowMessage(message);
                return;
            }

            NotificationService.ShowMessage("Contents of the shopping cart:\n");
            foreach (var item in ShoppingCart.SelectedProducts)
            {
                NotificationService.ShowMessage($"{item}\n");
            }

            Console.WriteLine();
        }

        public static bool CheckingSelectedProducts(out string msg)
        {
            msg = null;
            bool checkSelectedProducts = true;

            if (ShoppingCart.SelectedProducts == null)
            {
                checkSelectedProducts = false;
                msg = "Shopping cart is empty\n";
            }
            else if (ShoppingCart.SelectedProducts.Length > 10)
            {
                checkSelectedProducts = false;
                msg = "Quantity of products more than 10\n";
            }

            return checkSelectedProducts;
        }
    }
}
