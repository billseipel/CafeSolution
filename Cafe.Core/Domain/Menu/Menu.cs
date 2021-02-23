using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Core.Domain.Menu
{
    public class Menu
    {
        #region fields
        private ICollection<MenuItem> menuItems;
        #endregion

        #region CTOR
        public Menu(ICollection<MenuItem> _menuItems)
        {
            this.menuItems = _menuItems;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Get or set the menu items on the menu
        /// </summary>
        public virtual ICollection<MenuItem> MenuItems
        {
            get { return menuItems ?? (menuItems = new List<MenuItem>());  }
            set { menuItems = value; }
        }
        #endregion
    }
}
