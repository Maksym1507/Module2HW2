using System;
using System.Text;

namespace Practice_6
{
    public class OrderService
    {
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
                NotificationService.ShowMessage($"Order {order.ID} was formed. Quantity of products = {order.Quantity}\n");
                ShoppingCart.SelectedProducts = null;
                ShoppingCartService.StringBuilderSelectedProducts = new StringBuilder();
            }

            return order;
        }

        public static void ShowAllOrders(params Order[] orders)
        {
            NotificationService.ShowMessage("All orders:\n");
            if (orders.Length == 0)
            {
                NotificationService.ShowMessage("No orders\n");
                return;
            }
            else
            {
                for (int i = 0; i < orders.Length; i++)
                {
                    if (orders[i] != null)
                    {
                        NotificationService.ShowMessage($"Order {orders[i].ID}: \n");
                        for (int j = 0; j < orders[i].SelectedProducts.Length; j++)
                        {
                            NotificationService.ShowMessage(orders[i].SelectedProducts[j] + "\n");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
