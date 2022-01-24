using System;

namespace Practice_6
{
    internal class Program
    {
        public static void ShowAllOrders(Order[] orders)
        {
            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i] != null)
                {
                    Console.Write($"Order {orders[i].ID}: ");
                    for (int j = 0; j < orders[i].SelectedProducts.Length; j++)
                    {
                        Console.Write(orders[i].SelectedProducts[j] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }

        private static void Main()
        {
            var shoppingCart = new ShoppingCart();
            string[] listOfProducts =
            {
                "Shirt model 1",
                "T-shirt model 1",
                "Socks model 1",
                "Cap",
                "Jeans model 1",
                "Trousers",
                "Hat",
                "Gloves",
                "Hoodie",
                "Jacket model1",
                "Shirt model 2",
                "Socks model 2",
                "Jeans model 2"
            };

            shoppingCart.AddToShoppingCart(listOfProducts[6], listOfProducts[3], listOfProducts[7], listOfProducts[2], listOfProducts[0], listOfProducts[6], listOfProducts[3], listOfProducts[7], listOfProducts[2]);
            shoppingCart.ShowShoppingCart();
            Console.WriteLine();
            var order1 = shoppingCart.DoOrder();
            shoppingCart.ShowShoppingCart();
            var order2 = shoppingCart.DoOrder();
            Order[] orders = { order1, order2 };
            ShowAllOrders(orders);
        }
    }
}
