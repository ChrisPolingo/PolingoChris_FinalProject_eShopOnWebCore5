﻿using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        private Order()
        {
            // required by EF
        }

        public Order(string buyerId, Address shipToAddress, List<OrderItem> items)
        {
            Guard.Against.NullOrEmpty(buyerId, nameof(buyerId));
            Guard.Against.Null(shipToAddress, nameof(shipToAddress));
            Guard.Against.Null(items, nameof(items));

            BuyerId = buyerId;
            ShipToAddress = shipToAddress;
            _orderItems = items;
        }

        public string BuyerId { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; private set; }

        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method Order.AddOrderItem() which includes behavior.
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.UnitPrice * item.Units;
            }
            return total;
        }

        //Added to add the total tax in the grand total field
        /*
         * Calls the total method to gets the ammount of tax to be applied in the grand total.
         */
        public decimal Tax()
        {
            decimal total = Total();

            total = total * 0.06M;

            return total;
        }

        /*
         * Returns the sum of the total and the amount of tax.
         */
        public decimal grandTotal()
        {
            decimal grandTotal = Total() + Tax();

            return grandTotal;
        }
    }
}
