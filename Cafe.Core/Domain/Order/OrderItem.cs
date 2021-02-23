
using Cafe.Core.Domain.Menu;

namespace Cafe.Core.Domain.Order
{
    public class OrderItem
    {
        #region fields
        //auto properties
        #endregion

        #region CTOR
        public OrderItem(MenuItem _orderItem, int _orderitemQuantity)
        {
            ItemOrdered = _orderItem;
            ItemQuantity = _orderitemQuantity;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Menu Item ordered
        /// </summary>
        public MenuItem ItemOrdered { get; set; }

        public int ItemQuantity { get; set; }
        #endregion


    }
}
