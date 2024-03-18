namespace SamMRoberts.CardGame.Components
{
    public class Console : Component, IAsyncReader, IWriter, ICommunicator
    {
        public Console()
        {
        }

        public void Send(string message)
        {
            // TODO: Implement production code
            System.Diagnostics.Debug.WriteLine($"You entered: {message}.", $"[{nameof(Console)}.{nameof(Send)}]");
        }

        public void Write(string message)
        {
            System.Console.Write(FormatMessage(message));
        }

        public void WriteLine(string message)
        {
            System.Console.WriteLine(FormatMessage(message));
        }

        public override void Start()
        {
            SetState(States.Starting);
            Listen();
        }

        public override void Stop()
        {
            SetState(States.Stopping);
        }

        public override void SetManager(IManager manager)
        {
            if (this.State == States.Stopping || this.State == States.Starting)
                throw new System.Exception("Cannot set manager while component is starting or stopping.");
            if (_manager != null)
                throw new System.Exception("Component already has a manager.");
            _manager = manager;
        }

        public override void RemoveManager()
        {
            if (this.State != States.Stopped)
                throw new System.Exception("Cannot remove manager from a running component.");
            if (_manager == null)
                return;
            _manager = null;
        }

        public override IManager GetManager()
        {
            if (_manager == null)
                throw new System.Exception("Component does not have a manager.");
            return _manager;
        }

        private void Listen()
        {
            System.Diagnostics.Debug.WriteLine("Listener has started.", $"[{nameof(Console)}.{nameof(Listen)}]");
            Task listener = Task.Factory.StartNew(DoRead);
            listener.Wait();
            System.Diagnostics.Debug.WriteLine("Listener has stopped.", $"[{nameof(Console)}.{nameof(Listen)}]");
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
            SetState(States.Running);
            while(State == States.Running)
            {
                var input = System.Console.ReadLine();
                if (input == null)
                    continue;
                Send(input);
            }
        }
    }
}