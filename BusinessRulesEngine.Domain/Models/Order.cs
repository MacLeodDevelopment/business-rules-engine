namespace BusinessRulesEngine.Domain.Models
{
    public class Order
    {
        public Product Product { get; set; }

        public void SetPackingSlip(string shipping)
        {
            throw new System.NotImplementedException();
        }
    }
}