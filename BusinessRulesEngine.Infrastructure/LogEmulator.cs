using System;
using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Infrastructure
{
    public class LogEmulator : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}