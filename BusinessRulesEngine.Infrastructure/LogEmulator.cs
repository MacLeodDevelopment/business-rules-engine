using System;
using System.Diagnostics.CodeAnalysis;
using BusinessRulesEngine.Domain.Interfaces;

namespace BusinessRulesEngine.Infrastructure
{
    [ExcludeFromCodeCoverage(Justification = "because this implementation is an emulator for testing purposes.")]
    public class LogEmulator : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}