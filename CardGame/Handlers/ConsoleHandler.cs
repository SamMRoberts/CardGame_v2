using System.Diagnostics;
using SamMRoberts.CardGame.Components;

namespace SamMRoberts.CardGame.Handlers
{
    public enum ConsoleCommands
    {
        exit,
        help
    }

    public class ConsoleHandler : IStringHandler
    {
        public ConsoleHandler(Components.Console console)
        {
            _console = console;
        }

        public void Handle(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                _console.WriteLine("Please enter a command.");
                return;
            }
            System.Diagnostics.Debug.WriteLine($"You entered: {message}.", $"[{this.GetType().Name ?? string.Empty}::{nameof(ConsoleHandler)}.{nameof(Handle)}]");

            if (message.Substring(0, 1) == "/")
            {
                System.Diagnostics.Debug.WriteLine($"Command detected: {message}.", $"[{this.GetType().Name ?? string.Empty}::{nameof(ConsoleHandler)}.{nameof(Handle)}");
                var command = message.Substring(1).ToLower();
                if (Enum.TryParse<ConsoleCommands>(command, out var consoleCommand))
                {
                    switch (consoleCommand)
                    {
                        case ConsoleCommands.exit:
                            _console.WriteLine("Exiting game...");
                            _console.GetManager().Exit();
                            break;
                        case ConsoleCommands.help:
                            _console.WriteLine($"Available commands: {GetAvailableCommands()}");
                            break;
                        default:
                            _console.WriteLine($"Command not recognized: {message}.");
                            break;
                    }
                }
                else
                {
                    _console.WriteLine($"Command not recognized: {message}.");
                }
            }
            else
            {
                _console.WriteLine($"Echo: {message}.");
            }
        }

        private string GetAvailableCommands()
        {
            var consoleCommands = Enum.GetNames(typeof(ConsoleCommands));
            var availableCommands = string.Join(", ", consoleCommands);
            return availableCommands;
        }

        private Components.Console _console;
    }
}