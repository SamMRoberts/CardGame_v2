namespace SamMRoberts.CardGame
{
    public interface IManager
    {
        //void AddComponent(IComponent manageable);
        //void RemoveComponent(IComponent manageable);
        //void StartComponent(IComponent component);
        void StopComponent(IComponent component);
        void RestartComponent(IComponent component);
        void UpdateState(IComponent component, Enum state);
    }

    public interface IComponent : IManageable
    {
        IManager GetManager();
        void SetManager(IManager manager);
        void RemoveManager();
        void SetState(Components.Component.States state);
    }

    public interface IManageable
    {
        void Start();
        void Stop();
    }

    public interface IAsyncReader
    {
        //void Listen();
    }

    public interface IWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }

    public interface ICommunicator : IComponent
    {
        void Send(string message);
    }
}