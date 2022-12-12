using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.Web.Pages.Basket
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        public string BuyerId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }

        /*
         * Returns the total amount of tax on the current total of items in the basket
         */
        public decimal TotalTax()
        {
            return Math.Round(Total() * 0.06m, 2);
        }

        /*
         * Returns the Grand Total of the basket, being the sum of Total() and TotalTax().
         */
        public decimal GrandTotal()
        {
            return Total() + TotalTax();
        }
    }
}
