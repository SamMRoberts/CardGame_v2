namespace SamMRoberts.CardGame.Games
{
    public class GameFactory
    {
        public GameFactory()
        {
        }
        public static void Blackjack()
        {
            SamMRoberts.CardGame.Games.Blackjack.BlackjackEnvironment blackjackEnvironment = new();
        }
    }
}