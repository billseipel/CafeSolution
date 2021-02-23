using Cafe.Core.Domain.Menu;
using Cafe.Core.Domain.Order;
using Cafe.Services.Checkout;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cafe.Testing.NUnit
{
    [TestFixture]
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //    //create the order
        //    OrderItem oi1 = new OrderItem(new MenuItem("Cola", 0.50M, false, false), 3);
        //    OrderItem oi2 = new OrderItem(new MenuItem("Cheese Sandwich", 2.00M, true, false), 3);
        //    Order order = new Order(new List<OrderItem>() { oi1, oi2 });

        //    TotalIsRounded(order);


        //}

        [Test]
        public void TotalIsRoundedUsingOriginalValues()
        {
            decimal d = 8.25M;

            //create the order
            OrderItem oi1 = new OrderItem(new MenuItem("Cola", 0.50M, false, false), 3);
            OrderItem oi2 = new OrderItem(new MenuItem("Cheese Sandwich", 2.00M, true, false), 3);
            Order order = new Order(new List<OrderItem>() { oi1, oi2 });

            //create the Checkout service instance
            CheckoutService checkoutService = new CheckoutService(order);
            checkoutService.CalculateAll(order);

            //order sub total should be 7.50
            // service charge should be .75
            Assert.That(order.OrderTotal, Is.EqualTo(d));
            
        }

        [Test]
        public void TotalIsRoundedToOddValues()
        {
            decimal d = 8.78M;

            //create the order
            OrderItem oi1 = new OrderItem(new MenuItem("Cola", 0.53M, false, false), 3);
            OrderItem oi2 = new OrderItem(new MenuItem("Cheese Sandwich", 2.13M, true, false), 3);
            Order order = new Order(new List<OrderItem>() { oi1, oi2 });

            //create the Checkout service instance
            CheckoutService checkoutService = new CheckoutService(order);
            checkoutService.CalculateAll(order);

            //order sub total should be 7.98
            // service charge should be .80 (rounded from .798)
            Assert.That(order.OrderTotal, Is.EqualTo(d));

        }
    }
}