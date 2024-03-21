namespace SamMRoberts.CardGame.Cards.Decks.Types.Standard
{
    public enum Face : int { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    public enum Suit { Diamonds = '♦', Clubs = '♣', Hearts = '♥', Spades = '♠' }
    public enum Color { Red, Black }

    public class StandardDeckBuilder : DeckBuilder<Face, Suit, Color>
    {
        protected override Face Faces(Face face) => face;
        protected override Suit Suits(Suit suit) => suit;
        protected override Color Colors(Color color) => color;

        public override Deck NewDeck()
        {
            return new StandardDeck(this);
        }

        internal readonly ICardSymbolGetter<Face> symbols = new StandardCardSymbol();
    }

    public class StandardDeck : Deck
    {
        public StandardDeck(StandardDeckBuilder standardDeckBuilder) : base("Standard")
        {
            builder = standardDeckBuilder;
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    Cards.Add(new Card(face, builder.symbols.GetSymbol(face), suit,
                        (char)suit, suit == Suit.Diamonds || suit == Suit.Hearts ? Color.Red : Color.Black));
                }
            }
        }

        private readonly StandardDeckBuilder builder;
    }

    public class StandardCardSymbol : ICardSymbolGetter<Face>
    {
        public string GetSymbol(Face face)
        {
            if ((int)face > 10)
            {
                return face.ToString()[..1];
            }
            else
            {
                return ((int)face).ToString();
            }

            throw new NullReferenceException();
        }
    }
}