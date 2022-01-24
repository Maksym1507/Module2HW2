using System;
using System.Text;

namespace Practice_6
{
    public class ShoppingCart
    {
        private string[] _selectedProducts;

        public void AddToShoppingCart(params string[] selectedProducts)
        {
            _selectedProducts = selectedProducts;

            if (!CheckingSelectedProducts(out string message))
            {
                Console.WriteLine(message);
                return;
            }

            Console.WriteLine("Products were added to shopping cart");
        }

        public void ShowShoppingCart()
        {
            if (!CheckingSelectedProducts(out string message))
            {
                Console.WriteLine(message);
                return;
            }

            Console.Write("Products which were added to shopping cart: ");
            foreach (var item in _selectedProducts)
            {
                Console.Write(item + " ");
            }
        }

        public Order DoOrder()
        {
            Order order;

            if (!CheckingSelectedProducts(out string message))
            {
                Console.WriteLine(message);
                order = null;
            }
            else
            {
                order = new Order(_selectedProducts);
                order.Quantity = _selectedProducts.Length;
                Console.WriteLine($"Order {order.ID} was formed. Quantity of products = {order.Quantity}");
                _selectedProducts = null;
            }

            return order;
        }

        private bool CheckingSelectedProducts(out string msg)
        {
            msg = null;
            bool checkSelectedProducts = true;

            if (_selectedProducts == null)
            {
                checkSelectedProducts = false;
                msg = "Shopping cart is empty";
            }
            else if (_selectedProducts.Length > 10)
            {
                checkSelectedProducts = false;
                msg = "Quantity of products more than 10";
            }

            return checkSelectedProducts;
        }
    }
}
