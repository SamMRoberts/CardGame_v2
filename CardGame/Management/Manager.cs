using SamMRoberts.CardGame.Components;

namespace SamMRoberts.CardGame.Management
{
    public class Manager : IManager
    {
        public Manager()
        {
            _console = new Components.Console();
            _console.SetManager(this);
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

        public void UpdateState(IComponent component, Enum state)
        {
            System.Diagnostics.Debug.WriteLine($"Updating state of {component} to {state}", $"{nameof(Manager)}.{nameof(UpdateState)}");
            if (Components.TryGetValue(component, out var componentState))
                Components[component] = (Component.States)state;
            else
                Components.Add(component, (Component.States)state);
        }

        private Components.Console _console;
        public Dictionary<IComponent, Component.States> Components { get; } = new Dictionary<IComponent, Component.States>();
    }
}