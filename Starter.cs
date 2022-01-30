using System;

namespace Practice_6
{
    public class Starter
    {
        private readonly ShoppingCartService _shoppingCartService;
        private readonly OrderService _orderService;
        private Order _order;

        public Starter()
        {
            _shoppingCartService = new ShoppingCartService();
            _orderService = new OrderService();
        }

        public void Run()
        {
            CatalogService.ShowProducts();

            NotificationService.ShowMessage("Enter the number of orders:\n");

            int quantityOfOrders = Convert.ToInt32(Console.ReadLine());
            Order.Orders = new Order[quantityOfOrders];

            for (int i = 0; i < quantityOfOrders; i++)
            {
                NotificationService.ShowMessage("Add products to ShoppingCart:\n");
                string[] selectedProducts = Console.ReadLine().Split(',', StringSplitOptions.TrimEntries);
                ShoppingCart.SelectedProducts = selectedProducts;
                _shoppingCartService.AddToShoppingCart(ShoppingCart.SelectedProducts);
                ShoppingCartService.ShowShoppingCart();

                _order = _orderService.DoOrder();
                Order.Orders[i] = _order;
            }

            OrderService.ShowAllOrders(Order.Orders);
        }
    }
}
