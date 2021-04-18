namespace BusinessRulesEngine.Domain.Models
{
    public class Order
    {
        public string Id { get; }
        public virtual Product Product { get; private set; }
        public virtual PackingSlip PackingSlip { get; private set; }

        // ReSharper disable once UnusedMember.Global
        public Order() { }

        public Order(string id)
        {
            Id = id;
            PackingSlip = new PackingSlip();
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