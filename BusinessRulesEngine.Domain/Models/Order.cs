using System;

namespace BusinessRulesEngine.Domain.Models
{
    public class Order
    {
        public virtual string Id { get; }
        public virtual Product Product { get; private set; }
        public virtual PackingSlip PackingSlip { get; private set; }
        public virtual string AgentId { get; }
        public virtual DateTimeOffset Timestamp { get; }

        // ReSharper disable once UnusedMember.Global
        public Order() { }

        public Order(OrderConfig orderConfig)
        {
            Id = orderConfig.Id;
            AgentId = orderConfig.AgentId;
            Timestamp = DateTimeOffset.Now;
        }

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