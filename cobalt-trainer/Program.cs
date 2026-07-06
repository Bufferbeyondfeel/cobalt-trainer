using System;
using System.Threading;
using cobalt_trainer.Core;

namespace cobalt_trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cobalt Trainer - Enshrouded");
            Console.WriteLine("Controls: [F1] God Mode, [F2] Unlimited Stamina, [F3] Max Resources, [Esc] Exit");

            var memoryManager = new MemoryManager("Enshrouded");
            var trainer = new Trainer(memoryManager);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.F1:
                            trainer.ToggleGodMode();
                            Console.WriteLine($"God Mode: {trainer.GodModeEnabled}");
                            break;
                        case ConsoleKey.F2:
                            trainer.ToggleStamina();
                            Console.WriteLine($"Unlimited Stamina: {trainer.StaminaEnabled}");
                            break;
                        case ConsoleKey.F3:
                            trainer.MaxResources();
                            Console.WriteLine("Resources maxed out!");
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("Exiting...");
                            return;
                    }
                }
                Thread.Sleep(50);
            }
        }
    }
}