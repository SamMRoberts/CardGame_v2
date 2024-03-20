namespace SamMRoberts.CardGame.Cards.Decks
{
    public abstract class DeckBuilder<TFace, TSuit, TColor>
        where TFace : Enum
        where TSuit : Enum
        where TColor : Enum
    {
        protected Deck deck;
        protected abstract TFace Faces (TFace face);
        protected abstract TSuit Suits (TSuit suit);
        protected abstract TColor Colors (TColor color);

        public abstract Deck NewDeck();
    }

    public class Deck
    {
        private readonly string _deckType;
        private Dictionary<string, object> _components = [];

        public List<Card> Cards { get; } = [];
        public void RemoveCard(int index) => Cards.RemoveAt(index);
        public void PutCard(Card card, int index) => Cards.Insert(index, card);
        public string[] PeekCard(int index) => [Cards[index].Face.ToString(), Cards[index].Suit.ToString(), Cards[index].Color.ToString()];

        // Fisher-Yates shuffle
        public void Shuffle()
        {
            Random rng = new Random();
            int n = Cards.Count;
            IList<Card> tempCards = Cards;
            while (n > 1)
            {
                int k = rng.Next(n);
                n--;
                if (n == k) continue;
                Card temp = tempCards.ElementAt(n);
                Cards[n] = tempCards.ElementAt(k);
                Cards[k] = temp;
            }
        }

        public Deck(string deckType)
        {
            _deckType = deckType;
        }

        public void Show()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit + " (" + card.Color + ")");
            }
        }
    }
}