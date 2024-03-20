using System.Reflection;

namespace SamMRoberts.CardGame.Components
{
    enum Test {
        test1,
        test2
    }
    public class Console : ICommunicator
    {
        public Console(IComponentManager manager)
        {
            State = IStateful.States.Starting;
            _manager = manager;
            _handlers = [
                new Handlers.ConsoleHandler(this),
                new Handlers.DefaultHandler(this)
            ];
        }

        public void AddBlackjackHandlers()
        {
            _handlers.Insert(0, new Handlers.GameHandler(this));
        }

        public void Send(string message)
        {
            // TODO: Implement production code
            //_handler?.Handle(message);
            foreach (var handler in _handlers)
            {
                handler.Handle(message);
            }
        }

        public void Write(string message)
        {
            System.Console.Write(FormatMessage(message));
        }

        public void WriteLine(string message)
        {
            System.Console.WriteLine(FormatMessage(message));
        }

        public async Task Start()
        {
            ((IStateful)this).SetState(IStateful.States.Starting);
            await Listen();
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

        private void Listen0()
        {
            //Task listener = Task.Factory.StartNew(DoRead);
            //listener.Wait();
        }

        private static string GetTimeStamp()
        {
            return DateTime.Now.ToString("HH:mm:ss.ffff");
        }

        private static string FormatMessage(string message)
        {
            return $"[{GetTimeStamp()}] {message}";
        }

        private async Task Listen()
        {
            ((IStateful)this).SetState(IStateful.States.Running);
            await Task.Run(() =>
            {
                while (State == IStateful.States.Running)
                {
                    var input = System.Console.ReadLine();
                    if (input == null)
                        continue;
                    Send(input);
                }
            });
        }

        void IStateful.SetState(IStateful.States state)
        {
            State = state;
            if (_manager == null)
                throw new System.Exception("Component does not have a manager.");
        }

        public IStateful.States State { get; private set; } = IStateful.States.Stopped;

        private IComponentManager? _manager;
        //private IHandler<string>? _handler;
        private IList<IHandler<string>> _handlers;
    }
}