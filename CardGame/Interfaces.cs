namespace SamMRoberts.CardGame
{
    public interface IComponentManager
    {
        void StopComponent(IComponent component);
        void RestartComponent(IComponent component);
        void Exit();
    }

    public interface IComponent : IManageable, IStateful
    {
        IComponentManager GetManager();
        void SetManager(IComponentManager manager);
        void RemoveManager();
    }

    public interface IManageable
    {
        void Start();
        void Stop();
    }

    public interface IStringHandler
    {
        void Handle(string message);
    }

    public interface IAsyncReader
    {
        //void DoRead();
    }

    public interface IStateful
    {
        enum States
        {
            Starting,
            Running,
            Stopping,
            Stopped
        }
        States State { get; }
        void SetState(States state);
    }

    public interface IWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }

    public interface ICommunicator : IComponent, IAsyncReader, IWriter
    {
        void Send(string message);
    }
}