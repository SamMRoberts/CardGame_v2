namespace SamMRoberts.CardGame.Cards
{
    public readonly struct Card(Enum face, Enum suit, Enum color)
    {
        public Enum Face { get; } = face;
        public Enum Suit { get; } = suit;
        public Enum Color { get; } = color;

        public override readonly string ToString()
        {
            return $"{Face} {Suit}";
        }
    }
}