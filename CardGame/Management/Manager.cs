using SamMRoberts.CardGame.Components;

namespace SamMRoberts.CardGame.Management
{
    public class Manager : IComponentManager
    {
        public Manager()
        {
            _console = new Components.Console(this);
            StartComponent(_console);
        }

        public void StartComponent(IComponent component)
        {
            component.Start();
        }

        public void StopComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void RestartComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            System.Diagnostics.Debug.WriteLine("Exiting...", $"[{this.GetType().Name ?? string.Empty}::{nameof(Manager)}.{nameof(Exit)}]");
            System.Environment.Exit(0);
        }

        private Components.Console _console;
        private Handlers.ConsoleHandler _consoleHandler;
    }
}