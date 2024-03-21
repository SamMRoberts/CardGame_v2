namespace SamMRoberts.CardGame.Components
{
    public class Dealer : IComponent
    {
        public Dealer(IComponentManager manager)
        {
            _manager = manager;
        }

        public async Task Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public async Task Restart()
        {
            throw new NotImplementedException();
        }

        public IComponentManager GetManager()
        {
            throw new NotImplementedException();
        }

        public void SetManager(IComponentManager manager)
        {
            throw new NotImplementedException();
        }

        public void RemoveManager()
        {
            throw new NotImplementedException();
        }

        public void SetState(IStateful.States state)
        {
            throw new NotImplementedException();
        }

        private IComponentManager _manager;

        public IStateful.States State => throw new NotImplementedException();
    }
}