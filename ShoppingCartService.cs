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

        public void AddToShoppingCart(params string[] selectedProducts)
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
                    Console.WriteLine("This product(-s) is/are absent in catalog");
                    ShoppingCart.SelectedProducts = null;
                    return;
                }
            }

            ShoppingCart.SelectedProducts = StringBuilderSelectedProducts.ToString().TrimEnd(',').Split(",");

            if (!CheckingSelectedProducts(out string message))
            {
                Console.WriteLine(message);
                ShoppingCart.SelectedProducts = null;
                return;
            }

            Console.WriteLine("Product(-s) was/were added to shopping cart\n");
        }

        public static void ShowShoppingCart()
        {
            if (!CheckingSelectedProducts(out string message))
            {
                Console.WriteLine(message);
                return;
            }

            Console.WriteLine("Contents of the shopping cart: ");
            foreach (var item in ShoppingCart.SelectedProducts)
            {
                Console.Write(item + "\n");
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
                msg = "Shopping cart is empty";
            }
            else if (ShoppingCart.SelectedProducts.Length > 10)
            {
                checkSelectedProducts = false;
                msg = "Quantity of products more than 10";
            }

            return checkSelectedProducts;
        }
    }
}
