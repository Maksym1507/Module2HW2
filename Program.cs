using System;

namespace Practice_6
{
    internal class Program
    {
        private static void Main()
        {
            CatalogService.ShowProducts();
            var shoppingCartService = new ShoppingCartService();
            shoppingCartService.AddToShoppingCart("Hoodie", "Jeans model 2");
            ShoppingCartService.ShowShoppingCart();
            var orderService = new OrderService();
            var order1 = orderService.DoOrder();
            shoppingCartService.AddToShoppingCart("Shirt model 1", "T-shirt model 1", "Socks model 1", "Cap", "Jeans model 1", "Trousers", "Hat", "Gloves");
            ShoppingCartService.ShowShoppingCart();
            var order2 = orderService.DoOrder();
            OrderService.ShowAllOrders(order1, order2);
        }
    }
}
