using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
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
            var orders = UiEmulator.GetOrders();

            ProcessOrders(orders);

            if (UiEmulator.ProcessMoreOrders())
            {
                Main();
            }
        }

        /*
         * The public methods below allow the functionality of the application
         * to be acceptance tested without requiring UI interactions.
         */

        public static void ProcessOrders(IEnumerable<InputOrder> orders)
        {
            foreach (var inputOrder in orders)
            {
                var order = OrderBuilder.BuildOrderFromInput(inputOrder);
                OrderProcessor.ProcessOrder(order);
            }
        }

        public static IEnumerable<IBusinessEvent> GetPublishedEvents()
        {
            return ServiceBusEmulator.Events();
        }

        public static void ClearEvents()
        {
            ServiceBusEmulator.ClearEvents();
        }
    }
}
