/// Let's Write A Card Game!

using CS7_Alg_Cards;

var deck = InitializeDeck();
var deck2 = InitializeDeck();
var deck3 = InitializeDeck();

Card c = deck[17]; 
deck.RemoveAt(17);
if(deck.Contains(new(Suit.Spades, Value.Jack)))
    Console.WriteLine("Found it!");

Console.WriteLine("Type a card value! (with the \u2660 \u2661 \u2663 \u2662 suits)");
Card enteredCard = Console.ReadLine()!;  // Woah you can Type a card!~?!?!

if(c == enteredCard)
    Console.WriteLine("You guessed it!");
else
    foreach(var card in deck.OrderBy(c => c.Value))
        Console.WriteLine(card);

// End of Program

//-------------------------------------------------------
// Methods Start Here
//-------------------------------------------------------

List<Card> InitializeDeck(int aceHigh = 1)
{
    var deck = new List<Card>();
    foreach(var suit in Suit.AllSuits)
        foreach(var value in Value.AllValues.Take(13))
            deck.Add(new(suit, value));
    return deck;
}

void Swap(List<Card> cards, int a, int b) =>
    (cards[a], cards[b]) = (cards[b], cards[a]);

// remove the first card from the list and return it
Card DealOneFrom(List<Card> cards)
{
    return new();
}
// remove the first number of cards from the list and return them in a new list.
List<Card> DealFrom(List<Card> cards, int quantity)
{
    return new();
}
// insert a card randomly into the list of cards.
void InsertRandomlyInto(List<Card> cards, Card card)
{
    
}
// split the list of cards into two equal(ish) halfs and return both as new lists.
(List<Card>, List<Card>) Split(List<Card> cards)
{
    return new();
}
// Bonus:  Implement your Shuffling Algorithm
void Shuffle(List<Card> cards)
{
    
}
