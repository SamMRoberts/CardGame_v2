namespace SamMRoberts.CardGame
{
    public interface IComponentManager
    {
        Task StartComponent(IComponent component);
        void StopComponent(IComponent component);
        Task RestartComponent(IComponent component);
        void Exit();
    }

    public interface IComponent : IManageable, IStateful
    {
        IComponentManager GetManager();
        void SetManager(IComponentManager manager);
        void RemoveManager();
    }

    public interface IDealer
    {

    }

    public interface IManageable
    {
        Task Start();
        void Stop();
    }

    public interface IHandler<T>
    {
        void Handle(T message);
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

    public interface ICardSymbolGetter<TFace>
        where TFace : Enum
    {
        string GetSymbol(TFace face);
    }

    public interface ICardValueGetter<TFace>
        where TFace : Enum
    {
        int GetValue(TFace face);
    }

    public interface IGameManager
    {
        void AddPlayer();
        void RemovePlayer();
        void StartGame();
        void EndGame();
    }
}