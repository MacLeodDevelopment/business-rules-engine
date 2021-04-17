using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using BusinessRulesEngine.UI.InputModels;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessRulesEngine.UI
{
    public class Program
    {
        private static readonly IOrderProcessor OrderProcessor;

        static  Program()
        {
            var serviceProvider = IoC.DependencyResolver.ServiceProvider();
            OrderProcessor = serviceProvider.GetService<IOrderProcessor>();
        }

        public static void Main()
        {
            var inputOrders = new List<InputOrder>
            {
                new InputOrder { }
            }; //TODO AMACLEOD Populate from JSON files or something. 

            ProcessOrders(inputOrders);
        }

        public static void ProcessOrders(IEnumerable<InputOrder> orders)
        {
            foreach (var inputOrder in orders)
            {
                var order = GetOrder(inputOrder);
                OrderProcessor.ProcessOrder(order);
            }
        }

        public static IEnumerable<IBusinessEvent> GetPublishedEvents()
        {
            return new List<IBusinessEvent> {new PackingSlipCreated()};
        }

        private static Order GetOrder(InputOrder inputOrder)
        {
            return new Order();
        }
    }
}
