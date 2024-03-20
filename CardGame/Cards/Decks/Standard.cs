namespace SamMRoberts.CardGame.Cards.Decks.Types.Standard
{
    public enum Face { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    public enum Suit { Diamonds, Clubs, Hearts, Spades }
    public enum Color { Red, Black }

    public class StandardDeckBuilder : DeckBuilder<Face, Suit, Color>
    {
        protected override Face Faces(Face face) => face;
        protected override Suit Suits(Suit suit) => suit;
        protected override Color Colors(Color color) => color;

        public StandardDeckBuilder()
        {
            deck = new StandardDeck();
        }

        public override Deck NewDeck()
        {
            return new StandardDeck();
        }
    }

    public class StandardDeck : Deck
    {
        public StandardDeck() : base("Standard")
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    Cards.Add(new Card(face, suit, suit == Suit.Diamonds || suit == Suit.Hearts ? Color.Red : Color.Black));
                }
            }
        }
    }

    public class StandardCardEvaluator : CardEvaluator<Face>
    {
        protected override Face Faces(Face face) => face;

        public override string GetSymbol(Face face)
        {
            foreach (Face f in Enum.GetValues(typeof(Face)))
            {
                if ((int)f > 10)
                {
                    return f.ToString()[..1];
                }
                else
                {
                    return ((int)f).ToString();
                }
            }
            throw new NullReferenceException();
        }

        public override int GetValue(Face face)
        {
            foreach (Face f in Enum.GetValues(typeof(Face)))
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
}