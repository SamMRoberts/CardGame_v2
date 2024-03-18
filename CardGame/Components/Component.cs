namespace SamMRoberts.CardGame.Components
{
    public abstract class Component : IComponent
    {
        public enum States
        {
            Starting,
            Running,
            Stopping,
            Stopped
        }

        public abstract IManager GetManager();
        public abstract void SetManager(IManager manager);
        public abstract void RemoveManager();
        public abstract void Start();
        public abstract void Stop();
        public void SetState(States state)
        {
            System.Diagnostics.Debug.WriteLine($"Setting state of {this} to {state}", $"{nameof(Component)}.{nameof(SetState)}");
            State = state;
            if (_manager == null)
                throw new System.Exception("Component does not have a manager.");
            _manager.UpdateState(this, state);
        }

        protected IManager? _manager;
        public States State { get; private set; } = States.Stopped;
    }
}