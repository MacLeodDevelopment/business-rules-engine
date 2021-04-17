using System;
using System.Collections.Generic;
using BusinessRulesEngine.Services;
using BusinessRulesEngine.UI.InputModels;

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
            //var orderProcessor = new OrderProcessor();
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
