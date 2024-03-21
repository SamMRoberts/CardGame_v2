namespace SamMRoberts.CardGame.Management
{
    public abstract class Environment : IGameManager
    {
        public abstract bool HasDealer { get; }
        public abstract bool IsGameInProgress { get; }
        public abstract bool HasJokers { get; }
        public abstract int MaxPlayers { get; }
        public abstract int MinPlayers { get; }
        public abstract int NumberOfPlayers { get; }
        public abstract int NumberOfDecks { get; }
        public abstract int MaxDecks { get; }
        public abstract int MinDecks { get; }
        public abstract string GameName { get; }
        public abstract void AddPlayer();
        public abstract void RemovePlayer();
        public abstract void StartGame();
        public abstract void EndGame();
    }
}