using SamMRoberts.CardGame.Components;

namespace SamMRoberts.CardGame.Management
{
    public class Manager : IComponentManager
    {
        public Manager()
        {
            _console = new Components.Console(this);
            _console.AddBlackjackHandlers();
            Start().Wait();
        }

        public async Task Start()
        {
            WelcomeBanner();
            Task listener = StartComponent(_console);

            await listener;
        }

        public async Task StartComponent(IComponent component)
        {
            await component.Start();
        }

        public void StopComponent(IComponent component)
        {
            component.Stop();
        }

        public async Task RestartComponent(IComponent component)
        {
            component.Stop();
            await component.Start();
        }

        public void Exit()
        {
            _console.WriteLine("Exiting game...");
            System.Environment.Exit(0);
        }

        private void WelcomeBanner()
        {
            _console.WriteLine("Welcome to the card game!");
            _console.WriteLine("Type '/exit' to quit and /help for commands.");
        }

        private Components.Console _console;
    }
}