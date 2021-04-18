using System.Collections.Generic;
using BusinessRulesEngine.UI.InputModels;
using Newtonsoft.Json;

namespace BusinessRulesEngine.AcceptanceTests.Steps
{
    public static class OrderHelper
    {
        public static IEnumerable<InputOrder> GetOrderInput(string json)
        {
            var order = JsonConvert.DeserializeObject<InputOrder>(json);
            var orders = new List<InputOrder> { order };
            return orders;
        }
    }
}