using System.Diagnostics;
//using SamMRoberts.CardGame.Components;

namespace SamMRoberts.CardGame.Handlers
{
    public class ConsoleHandler : IHandler<string>
    {
        internal enum Commands
        {
            exit,
            help
        }

        public ConsoleHandler(Components.Console console)
        {
            _console = console;
        }

        public virtual void Handle(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                _console.WriteLine("Please enter a command.");
                return;
            }

            if (IsCommand(message))
            {
                var command = ParseCommand(message);
                if (Enum.TryParse<Commands>(command, out var consoleCommand))
                {
                    switch (consoleCommand)
                    {
                        case Commands.exit:
                            _console.GetManager().Exit();
                            break;
                        case Commands.help:
                            _console.WriteLine($"Console commands: {GetAvailableCommands<Commands>()}");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected static bool IsCommand(string message)
        {
            return message[..1] == "/";
        }

        protected static string ParseCommand(string message)
        {
            return message[1..].ToLower();
        }

        protected static string GetAvailableCommands<T>()
        {
            var Commands = Enum.GetNames(typeof(T));
            var availableCommands = string.Join(", ", Commands);
            return availableCommands;
        }

        protected Components.Console _console;
    }
}