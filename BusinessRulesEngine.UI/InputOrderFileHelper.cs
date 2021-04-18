using System.Collections.Generic;
using BusinessRulesEngine.SharedResources;
using BusinessRulesEngine.UI.InputModels;
using Newtonsoft.Json;

namespace BusinessRulesEngine.UI
{
    public static class InputOrderFileHelper
    {
        private static readonly List<InputOrder> AllScenarios;

        static InputOrderFileHelper()
        {
            AllScenarios = new List<InputOrder>
            {
                JsonConvert.DeserializeObject<InputOrder>(Orders.Physical_Product_json),
                JsonConvert.DeserializeObject<InputOrder>(Orders.Book_json),
                JsonConvert.DeserializeObject<InputOrder>(Orders.Membership_Activation_json),
                JsonConvert.DeserializeObject<InputOrder>(Orders.Membership_Upgrade_json),
                JsonConvert.DeserializeObject<InputOrder>(Orders.Video_json)
            };
        }

        public static IEnumerable<InputOrder> GetOrdersForScenario(int scenarioNumber)
        {
            switch (scenarioNumber)
            {
                case 1:
                case 8:
                    return AllScenarios.GetRange(0, 1); //Physical Product
                case 2:
                case 9:
                    return AllScenarios.GetRange(1, 1); //Book 
                case 3:
                case 5:
                    return AllScenarios.GetRange(2, 1); //Membership Activated
                case 4:
                case 6:
                    return AllScenarios.GetRange(3, 1); //Membership Upgrade
                case 7:
                    return AllScenarios.GetRange(4, 1); //Video
                case 10:
                    return AllScenarios;
                default:
                    return new List<InputOrder>();
            }
        }
    }
}