﻿namespace BusinessRulesEngine.Domain.Models
{
    public class Order
    {
        public Product Product { get; private set; }
        public PackingSlip PackingSlip { get; private set; }

        public virtual void SetPackingSlip(PackingSlip packingSlip)
        {
            PackingSlip = packingSlip;
        }

        public virtual void SetProduct(Product product)
        {
            Product = product;
        }
    }
}