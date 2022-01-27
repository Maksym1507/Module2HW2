using System;

namespace Practice_6
{
    public class NotificationService
    {
        public static void OrderNotice(Order order)
        {
            Console.WriteLine($"Order {order.ID} was formed. Quantity of products = {order.Quantity}\n");
        }
    }
}
