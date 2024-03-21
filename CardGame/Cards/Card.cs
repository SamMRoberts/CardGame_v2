namespace SamMRoberts.CardGame.Cards
{
    public readonly struct Card(Enum face, string faceSymbol, Enum suit, char suitSymbol, Enum color)
    {
        public Enum Face { get; } = face;
        public string FaceSymbol { get; } = faceSymbol;
        public Enum Suit { get; } = suit;
        public char SuitSymbol { get; } = suitSymbol;
        public Enum Color { get; } = color;

        public override readonly string ToString()
        {
            return $"{Face} {Suit}";
        }
    }
}