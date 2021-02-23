using Cafe.Core.Domain.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Services.Checkout
{
    public class CheckoutService : ICheckoutService
    {

        #region fields
        private readonly Order order;

        #endregion

        #region CTOR
        public CheckoutService(Order _order)
        {
            order = _order;
        }
        #endregion

        #region methods

        public void CalculateAll(Order order)
        {
            if (order != null)
            {
                CalculateSubTotal(order);
                CalculateServiceCharge(order);
                CalculateTotal(order);
            }
            else
            {
                throw new Exception("Order cannot be null");
            }
        }

        private decimal CalculateTotal(Order order)
        {
            //Assign the service charge
            order.OrderServiceCharge = CalculateServiceCharge(order);
            //Assign order total
            order.OrderTotal = Math.Round((order.OrderSubTotal + order.OrderServiceCharge), 2, MidpointRounding.AwayFromZero);
            return order.OrderTotal;
        }

        private decimal CalculateServiceCharge(Order order)
        {
           // iterates the order for FOOD
            if (order.ServiceChargeIsApplicable())
            {
                return Math.Round((order.OrderSubTotal / 10),2,MidpointRounding.AwayFromZero);
            }
            else 
            {
                return 0;
            }
        }

        private decimal CalculateSubTotal(Order order)
        {
            foreach (OrderItem oi in order.OrderItems)
            {
                order.OrderSubTotal += Math.Round((oi.ItemOrdered.MenuItemPrice * oi.ItemQuantity),2,MidpointRounding.AwayFromZero);
            }

            return order.OrderSubTotal;
        }
        #endregion

    }
}
