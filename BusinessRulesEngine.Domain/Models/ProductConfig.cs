namespace BusinessRulesEngine.Domain.Models
{
    /// <remarks>
    /// Exists only to avoid constructing product with multiple strings (code smell).
    /// In a real application Product would likely have specific object type properties
    /// rather than simple strings.
    /// </remarks>
    public class ProductConfig
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
    }
}