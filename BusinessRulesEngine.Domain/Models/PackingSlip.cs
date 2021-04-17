namespace BusinessRulesEngine.Domain.Models
{
    public class PackingSlip
    {
        public string Department { get; }

        public PackingSlip(string department)
        {
            Department = department;
        }
    }
}