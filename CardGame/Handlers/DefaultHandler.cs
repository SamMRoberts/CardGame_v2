namespace SamMRoberts.CardGame.Handlers
{
    public class DefaultHandler : ConsoleHandler
    {

        public DefaultHandler(Components.Console console) : base(console)
        {
            _console = console;
        }

        public override void Handle(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            if (IsCommand(message)) return;
            else _console.WriteLine($"You say to yourself, \"{message}\".");
        }
    }
}