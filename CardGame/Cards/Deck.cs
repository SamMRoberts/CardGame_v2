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

        public IList<Card> Cards { get; } = [];
        public void RemoveCard(int index) => Cards.RemoveAt(index);
        public void PutCard(Card card, int index) => Cards.Insert(index, card);
        public string[] PeekCard(int index) => [Cards[index].Face.ToString(), Cards[index].Suit.ToString(), Cards[index].Color.ToString()];

        public void Shuffle()
        {
            Shuffle(Cards);
        }
        // Fisher-Yates shuffle
        public static void Shuffle<T>(IList<T> objects) where T : new()
        {
            for (int i = 0; i < objects.Count - 1; i++)
            {
                int j = GenerateRandomNumber(i, objects.Count);
                (objects[j], objects[i]) = (objects[i], objects[j]);
            }
        }

        public static Random random = new Random(0);
        public static int GenerateRandomNumber(int from, int to) => random.Next(from, to);

        public Deck(string deckType)
        {
            _deckType = deckType;
        }

        public void Show()
        {
            foreach (var card in Cards)
            {
                if (card.Color.ToString() == "Red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(card.FaceSymbol.ToString() + card.SuitSymbol);
            }
            Console.WriteLine($"Total cards: {Cards.Count}");
        }
    }
}