namespace SamMRoberts.CardGame.Handlers
{
    public class GameHandler : ConsoleHandler, IHandler<string>
    {
        internal new enum Commands
        {
            hit,
            stand,
            help
        }
        public GameHandler(Components.Console console) : base(console)
        {
            _console = console;
        }

        public override void Handle(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                _console.WriteLine("Please enter a command.");
                return;
            }

            if (IsCommand(message))
            {
                var command = message.Substring(1).ToLower();
                if (Enum.TryParse<Commands>(command, out var consoleCommand))
                {
                    switch (consoleCommand)
                    {
                        case Commands.hit:
                            _console.WriteLine("Hit...");
                            break;
                        case Commands.stand:
                            _console.WriteLine("Stand...");
                            break;
                        case Commands.help:
                            _console.WriteLine($"Game commands: {GetAvailableCommands<Commands>()}");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}