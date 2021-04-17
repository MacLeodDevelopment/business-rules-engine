using System;
using System.Collections.Generic;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;
using BusinessRulesEngine.Services;
using BusinessRulesEngine.UI.InputModels;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessRulesEngine.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void ProcessOrders(IEnumerable<InputOrder> orders)
        {
            var serviceProvider = IoC.DependencyResolver.ServiceProvider();
            var orderProcessor = serviceProvider.GetService<IOrderProcessor>();

            foreach (var inputOrder in orders)
            {
                var order = new Order();
                orderProcessor.ProcessOrder(order);
            }
        }

        public static IEnumerable<IBusinessEvent> GetPublishedEvents()
        {
            return new List<IBusinessEvent> {new PackingSlipCreated()};
        }
    }

    public class PackingSlipCreated : IBusinessEvent
    {
        public string Message { get; }

        public PackingSlipCreated()
        {
            Message = "Packing Slip Created";
        }
    }

    public interface IBusinessEvent
    {
        string Message { get; }
    }
}
