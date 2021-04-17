using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Domain.Models.Events;
using BusinessRulesEngine.Infrastructure;
using BusinessRulesEngine.UI.InputModels;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessRulesEngine.UI
{
    public class Program
    {
        private static readonly IOrderProcessor OrderProcessor;
        private static readonly IServiceBus ServiceBusEmulator;

        static  Program()
        {
            var serviceProvider = IoC.DependencyResolver.ServiceProvider();
            OrderProcessor = serviceProvider.GetService<IOrderProcessor>();
            ServiceBusEmulator = serviceProvider.GetService<IServiceBus>();
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
            return ServiceBusEmulator.Events();
        }

        private static Order GetOrder(InputOrder inputOrder)
        {
            return new Order();
        }
    }
}
