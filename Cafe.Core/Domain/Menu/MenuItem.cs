using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Core.Domain.Menu
{
    public class MenuItem
    {
        #region fields
        // all auto-properties
        #endregion

        #region CTOR
        public MenuItem(string _menuitemName, decimal _menuitemPrice, bool _isFood, bool _isHot)
        { 
            MenuItemName = _menuitemName;
            MenuItemPrice = _menuitemPrice;
            IsFood = _isFood;
            IsHot = _isHot;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the name of the menu item.
        /// </summary>
        public string MenuItemName { get; set; }

        public bool IsHot { get; set; }


        /// <summary>
        /// Get or set the price of the menu item
        /// </summary>
        public decimal MenuItemPrice { get; set; }

        /// <summary>
        /// Gets or sets whether the menu item is food
        /// </summary>
        public bool IsFood { get; set; }

        #endregion
    }
}
