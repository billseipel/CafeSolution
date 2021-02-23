using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Core.Domain.Order
{
    public class Order
    {
        #region fields
        private ICollection<OrderItem> orderItems;
        private bool HasServiceCharge = false;

        #endregion

        #region CTOR
        public Order(ICollection<OrderItem> _orderItems)
        {
            orderItems = _orderItems;
        }
        #endregion

        /// <summary>
        /// Get or Set the total of the order
        /// </summary>
        #region Properties
        public decimal OrderTotal { get; set; }

        public decimal OrderSubTotal { get; set; }

        /// <summary>
        /// Gets or sets the order Service Charge
        /// </summary>
        public decimal OrderServiceCharge { get; set; } = 0;

        public ICollection<OrderItem> OrderItems
        {
            get { return orderItems?? (orderItems = new List<OrderItem>()); }
            set { orderItems = value; }
        }

        #endregion
        /// <summary>
        /// Iterates the collection of OrderItems looking whether an ordered item is food.
        /// </summary>
        /// <returns>True if just one item is food. Otherwise false by default.</returns>
        public bool ServiceChargeIsApplicable()
        {
            foreach (OrderItem oi in this.orderItems)
            {
                if (oi.ItemOrdered.IsFood)
                {
                    HasServiceCharge = true;
                }
            }
            return HasServiceCharge;
        }
    }
}
