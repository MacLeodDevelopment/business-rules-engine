﻿using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Domain.Rules
{
    public class GeneratePackingSlipForPhysicalProduct : IRule
    {
        public bool IsMatch(Order order)
        {
            return order?.Product?.ProductType == "Physical";
        }

        public void Apply(Order order)
        {
            var packingSlip = new PackingSlip("Shipping");
            order.SetPackingSlip(packingSlip);
        }
    }
}