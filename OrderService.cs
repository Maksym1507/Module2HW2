using System;
using System.Text;

namespace Practice_6
{
    public class OrderService
    {
        public static void ShowAllOrders(params Order[] orders)
        {
            Console.WriteLine("All orders:");
            if (orders.Length == 0)
            {
                Console.WriteLine("No orders");
                return;
            }
            else
            {
                for (int i = 0; i < orders.Length; i++)
                {
                    if (orders[i] != null)
                    {
                        Console.WriteLine($"Order {orders[i].ID}: ");
                        for (int j = 0; j < orders[i].SelectedProducts.Length; j++)
                        {
                            Console.Write(orders[i].SelectedProducts[j] + "\n");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }

        public Order DoOrder()
        {
            Order order;

            if (!ShoppingCartService.CheckingSelectedProducts(out string message))
            {
                Console.WriteLine(message);
                order = null;
            }
            else
            {
                order = new Order(ShoppingCart.SelectedProducts);
                order.Quantity = ShoppingCart.SelectedProducts.Length;
                NotificationService.OrderNotice(order);
                ShoppingCart.SelectedProducts = null;
                ShoppingCartService.StringBuilderSelectedProducts = new StringBuilder();
            }

            return order;
        }
    }
}
