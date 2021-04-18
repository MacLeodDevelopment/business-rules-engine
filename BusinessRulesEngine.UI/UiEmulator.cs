using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BusinessRulesEngine.UI.InputModels;
using Newtonsoft.Json;

namespace BusinessRulesEngine.UI
{
    [ExcludeFromCodeCoverage(Justification = "because this implementation is an emulator for testing purposes.")]
    public static class UiEmulator
    {
        public static IEnumerable<InputOrder> GetOrders()
        {
            WriteIntroduction();

            var scenarioChoice = GetScenarioChoice(Console.ReadKey().Key);
            var orders = InputOrderFileHelper.GetOrdersForScenario(scenarioChoice);

            WriteResultsHeader();

            return orders;
        }

        public static bool ProcessMoreOrders()
        {
            WriteResultsFooter();
            var processMoreDecision = Console.ReadKey().Key;

            return processMoreDecision == ConsoleKey.Y;
        }

        public static void WriteInputOrder(InputOrder inputOrder)
        {
            var orderJson = JsonConvert.SerializeObject(inputOrder, Formatting.Indented);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"Input JSON was:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(orderJson);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        private static void WriteIntroduction()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"             ___              __                     __  ___           __                   __");
            Console.WriteLine(@"            /   |  ____  ____/ /_______ _      __   /  |/  /___ ______/ /   ___  ____  ____/ /");
            Console.WriteLine(@"           / /| | / __ \/ __  / ___/ _ \ | /| / /  / /|_/ / __ `/ ___/ /   / _ \/ __ \/ __  /");
            Console.WriteLine(@"          / ___ |/ / / / /_/ / /  /  __/ |/ |/ /  / /  / / /_/ / /__/ /___/  __/ /_/ / /_/ /");
            Console.WriteLine(@"         /_/  |_/_/ /_/\__,_/_/   \___/|__/|__/  /_/  /_/\__,_/\___/_____/\___/\____/\__,_/");
            Console.WriteLine(@"");
            Console.WriteLine(@"   ____           __             ____                                               ______          __");
            Console.WriteLine(@"  / __ \_________/ /__  _____   / __ \_________  ________  ______________  _____   /_  __/__  _____/ /_");
            Console.WriteLine(@" / / / / ___/ __  / _ \/ ___/  / /_/ / ___/ __ \/ ___/ _ \/ ___/ ___/ __ \/ ___/    / / / _ \/ ___/ __/");
            Console.WriteLine(@"/ /_/ / /  / /_/ /  __/ /     / ____/ /  / /_/ / /__/  __(__  |__  ) /_/ / /       / / /  __(__  ) /_");
            Console.WriteLine(@"\____/_/   \__,_/\___/_/     /_/   /_/   \____/\___/\___/____/____/\____/_/       /_/  \___/____/\__/");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"_______________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine(@"Please choose one of the following orders to process:");
            Console.WriteLine();
            Console.WriteLine(@"1. An order containing a physical product will generate a packing slip for shipping.");
            Console.WriteLine(@"2. An order containing a book will create a duplicate packing slip for the Royalty Department.");
            Console.WriteLine(@"3. An order for a membership will activate the membership.");
            Console.WriteLine(@"4. An order for a membership upgrade will apply the upgrade.");
            Console.WriteLine(@"5. An order for a membership will email the owner.");
            Console.WriteLine(@"6. An order for a membership upgrade will email the owner.");
            Console.WriteLine(@"7. An order for 'Learning to Ski' adds a free 'First Aid' video to the packing slip.");
            Console.WriteLine(@"8. An order containing a physical product will generate a commission payment to the agent.");
            Console.WriteLine(@"9. An order containing a book will generate a commission payment to the agent.");
            Console.WriteLine();
            Console.WriteLine(@"Enter a number 1-9 to run a scenario, or press A to run all scenarios.");
            Console.WriteLine();
        }

        private static void WriteResultsHeader()
        {
            Console.WriteLine();
            Console.WriteLine(@"=====================================");
            Console.WriteLine(@"Results:");
            Console.WriteLine(@"=====================================");
            Console.WriteLine();
        }

        private static int GetScenarioChoice(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return 1;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return 2;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return 3;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return 4;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    return 5;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    return 6;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    return 7;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    return 8;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    return 9;
                case ConsoleKey.A:
                    return 10;
                default:
                    Console.WriteLine();
                    Console.WriteLine(@"Please enter a number from 1 to 9.");
                    return GetScenarioChoice(Console.ReadKey().Key);
            }
        }

        private static void WriteResultsFooter()
        {
            Console.WriteLine();
            Console.WriteLine(@"=====================================");
            Console.WriteLine();
            Console.WriteLine(@"Process another? Press Y to process more, or any other key to finish.");
            Console.WriteLine();
        }
    }
}