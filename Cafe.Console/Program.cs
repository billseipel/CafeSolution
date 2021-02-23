using Cafe.Core.Domain.Menu;
using Cafe.Core.Domain.Order;
using Cafe.Services.Checkout;
using System;
using System.Collections.Generic;

namespace Cafe
{
    public class Program
    {
        static void Main(string[] args)
        {
            //initialize new menu items
            // Food
            MenuItem cheeseSandwich = new MenuItem("Cheese Sandwich", 2.00M, true, false);
            MenuItem steakSandwich = new MenuItem("Steak Sandwich", 4.50M, true,true);
          
            // Drinks
            MenuItem cola = new MenuItem("Cola", 0.50M, false,false);
            MenuItem coffee = new MenuItem("Coffee", 1.00M, true,true);

            //initialize the collection of menu items
            List<MenuItem> menuitemList = new List<MenuItem>() { cheeseSandwich, steakSandwich, cola, coffee};

            //create the new menu
            Menu menu = new Menu(menuitemList);



            //create new orderitems
            OrderItem oi1 = new OrderItem(cheeseSandwich, 2);
            OrderItem oi2 = new OrderItem(cola, 2);
            //create the order list
            List<OrderItem> orderList = new List<OrderItem>() { oi1, oi2 };
            //create the order
            Order order = new Order(orderList);

            CheckoutService checkoutService = new CheckoutService(order);
            checkoutService.CalculateAll(order);

            Console.WriteLine("You ordered: ");

            foreach(OrderItem oi in order.OrderItems)
            {
                Console.WriteLine("Quantity: " + oi.ItemQuantity + " " + oi.ItemOrdered.MenuItemName + " at a price of $" + oi.ItemOrdered.MenuItemPrice + " Each");

            }
            Console.WriteLine("Your subtotal is: $" + order.OrderSubTotal);
            Console.WriteLine("You incurred a service charge of " + order.OrderServiceCharge);
            Console.WriteLine("You order total is $" + order.OrderTotal);
            Console.Read();






        }
    }

}
