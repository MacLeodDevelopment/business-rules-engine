using System;
using System.Diagnostics.CodeAnalysis;
using BusinessRulesEngine.Domain.Interfaces;
using BusinessRulesEngine.Domain.Models;

namespace BusinessRulesEngine.Infrastructure
{
    [ExcludeFromCodeCoverage(Justification = "because this implementation is an emulator for testing purposes.")]
    public class LogEmulator : ILogger
    {
        public void Log(string message, MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageType.Information:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}