using Components = SamMRoberts.CardGame.Components;
using Management = SamMRoberts.CardGame.Management;
using SamMRoberts.CardGame;
using SamMRoberts.CardGame.Cards.Decks;
using SamMRoberts.CardGame.Cards.Decks.Types.Standard;

//IComponentManager manager = new Management.Manager();
StandardDeckBuilder builder = new StandardDeckBuilder();
Deck deck = builder.NewDeck();
Console.WriteLine("----------------- Shuffle -----------------");
deck.Shuffle();
deck.Show();
Deck deck2 = builder.NewDeck();
Console.WriteLine("----------------- Shuffle -----------------");
deck2.Shuffle();
deck2.Show();