using StandardDeck = SamMRoberts.CardGame.Cards.Decks.Types.Standard;

namespace SamMRoberts.CardGame.Games.Blackjack
{
    public class BlackjackCardValue : ICardValueGetter<StandardDeck.Face>
    {
        public int GetValue(StandardDeck.Face face)
        {
            foreach (StandardDeck.Face f in Enum.GetValues(typeof(StandardDeck.Face)))
            {
                if (f.ToString() == "Ace")
                {
                    return 11;
                }
                else if ((int)f > 10)
                {
                    return 10;
                }
                else
                {
                    return (int) f;
                }
            }
            throw new NullReferenceException();
        }
    }

    public class BlackjackEnvironment : Management.Environment
    {
        public BlackjackEnvironment()
        {
            StandardDeck.StandardDeckBuilder builder = new StandardDeck.StandardDeckBuilder();
            Cards.Decks.Deck deck = builder.NewDeck();
            deck.Shuffle();
            deck.Show();
        }

        public override bool HasDealer { get; } = true;
        public override bool IsGameInProgress { get; } = false;
        public override bool HasJokers { get; } = false;
        public override int MaxPlayers { get; } = 1;
        public override int MinPlayers { get; } = 1;
        public override int NumberOfPlayers { get; } = 1;
        public override int NumberOfDecks { get; } = 1;
        public override int MaxDecks { get; } = 1;
        public override int MinDecks { get; } = 1;
        public override string GameName { get; } = "Blackjack";
        public override void AddPlayer() => throw new NotImplementedException();
        public override void RemovePlayer() => throw new NotImplementedException();
        public override void StartGame() => throw new NotImplementedException();
        public override void EndGame() => throw new NotImplementedException();
    }
}