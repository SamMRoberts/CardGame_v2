using System.Reflection;

namespace SamMRoberts.CardGame.Components
{
    public class Console : ICommunicator
    {
        public Console(IComponentManager manager)
        {
            _manager = manager;
            _handler = new Handlers.ConsoleHandler(this);
        }

        public void Send(string message)
        {
            // TODO: Implement production code
            _handler?.Handle(message);
        }

        public void Write(string message)
        {
            System.Console.Write(FormatMessage(message));
        }

        public void WriteLine(string message)
        {
            System.Console.WriteLine(FormatMessage(message));
        }

        public void Start()
        {
            ((IStateful)this).SetState(IStateful.States.Starting);
            Listen();
        }

        public void Stop()
        {
            ((IStateful)this).SetState(IStateful.States.Stopping);
        }

        public void SetManager(IComponentManager manager)
        {
            if (this.State == IStateful.States.Stopping || this.State == IStateful.States.Starting)
                throw new System.Exception("Cannot set manager while component is starting or stopping.");
            if (_manager != null)
                throw new System.Exception("Component already has a manager.");
            _manager = manager;
        }

        public void RemoveManager()
        {
            if (this.State != IStateful.States.Stopped)
                throw new System.Exception("Cannot remove manager from a running component.");
            if (_manager == null)
                return;
            _manager = null;
        }

        public IComponentManager GetManager()
        {
            if (_manager == null)
                throw new System.Exception("Component does not have a manager.");
            return _manager;
        }

        private void Listen()
        {
            System.Diagnostics.Debug.WriteLine("Listener has started.", $"[{this.GetType()?.Name}.{MethodBase.GetCurrentMethod()?.Name}]");
            Task listener = Task.Factory.StartNew(DoRead);
            listener.Wait();
            System.Diagnostics.Debug.WriteLine("Listener has stopped.", $"[{this.GetType()?.Name ?? string.Empty}::{nameof(Console)}.{nameof(Listen)}]");
        }

        private static string GetTimeStamp()
        {
            return DateTime.Now.ToString("HH:mm:ss.ffff");
        }

        private static string FormatMessage(string message)
        {
            return $"[{GetTimeStamp()}] {message}";
        }

        private void DoRead()
        {
            ((IStateful)this).SetState(IStateful.States.Running);
            while(State == IStateful.States.Running)
            {
                var input = System.Console.ReadLine();
                if (input == null)
                    continue;
                Send(input);
            }
        }

        void IStateful.SetState(IStateful.States state)
        {
            System.Diagnostics.Debug.WriteLine($"Setting state of {this} to {state}", $"[{this.GetType().Name ?? string.Empty}::{nameof(Console)}.{nameof(IStateful.SetState)}]");
            State = state;
            if (_manager == null)
                throw new System.Exception("Component does not have a manager.");
        }

        public IStateful.States State { get; private set; } = IStateful.States.Stopped;

        private IComponentManager? _manager;
        private IStringHandler? _handler;
    }
}