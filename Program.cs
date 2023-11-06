/// Let's Write A Card Game!

using System.Runtime.Serialization;
using System.Security.Cryptography;
using CS7_Alg_Cards;

#region Initialization
Random RNG = new();
var deck = InitializeDeck();
Shuffle(deck);
(var p1, var p2) = Split(deck);
#endregion

#region The Game!

// until one player is out of cards.
while (p1.Any() && p2.Any())
{
    Console.WriteLine($"Player 1 has {p1.Count} cards");
    Console.WriteLine($"Player 2 has {p2.Count} cards");
    var c1 = DealOneFrom(p1);
    var c2 = DealOneFrom(p2);
    Console.WriteLine($"Player 1:  {c1}\t:\tPlayer 2:  {c2}");
    Console.ReadKey(); 
    if (c1.Value > c2.Value)
    {
        Console.WriteLine("Player 1 Wins the round!");
        p1.Add(c1);
        p1.Add(c2);
    }
    else if (c2.Value > c1.Value)
    {
        Console.WriteLine("Player 2 Wins the round!");
        p2.Add(c1);
        p2.Add(c2);
    }
    else
    {
        Console.WriteLine("WARRRRRRR");
        WAR(p1, p2, c1, c2);
    }
}

Console.WriteLine($"Player {(p1.Any()?1:2)} Wins!");



void WAR(List<Card> p1, List<Card> p2, Card c1, Card c2, List<Card>? wz = default)
{
    if (wz == default)
        wz = new () {c1, c2};
    else
    {
        wz.Add(c1);
        wz.Add(c2);
    }
    // Deal 3 each from p1 and p2 into warzone
    
    wz.AddRange(DealFrom(p1, 3));
    wz.AddRange(DealFrom(p2, 3));
    c1 = DealOneFrom(p1);
    c2 = DealOneFrom(p2);
    Console.WriteLine($"Player 1:  {c1}\t:\tPlayer 2:  {c2}");
    Console.ReadKey();
    if (c1.Value > c2.Value)
    {
        Console.WriteLine($"Player 1 wins the WAR with {wz.Count + 2} cards!");
        p1.Add(c1);
        p1.Add(c2);
        p1.AddRange(wz);
    }
    else if (c2.Value > c1.Value)
    {
        Console.WriteLine($"Player 2 wins the WAR with {wz.Count + 2} cards!");
        p2.Add(c1);
        p2.Add(c2);
        p2.AddRange(wz);
    }
    else
    {
        Console.WriteLine("OMG AGAIN");
        WAR(p1, p2, c1, c2, wz);
    }
}

#endregion



// End of Program

//-------------------------------------------------------
#region Methods Start Here
//-------------------------------------------------------

List<Card> InitializeDeck(int aceHigh = 1)
{
    if (aceHigh < 0 || aceHigh > 1)
        aceHigh = 1;
    var deck = new List<Card>();
    foreach(var suit in Suit.AllSuits)
        foreach(var value in Value.AllValues.Take(13))
            deck.Add(new(suit, value));
    return deck;
}

void Swap(List<Card> cards, int a, int b)
{
    if (!cards.Any())
        return;

    if (a < 0 || a >= cards.Count ||
        b < 0 || b >= cards.Count)
        return;
    
    (cards[a], cards[b]) = (cards[b], cards[a]);
}

// remove the first card from the list and return it
Card DealOneFrom(List<Card> cards)
{
    if (!cards.Any())
    {
        throw new InvalidOperationException("You don't have any cards!");
    }
    var card = cards[0];
    cards.RemoveAt(0);
    return card;
}
// remove the first number of cards from the list and return them in a new list.
List<Card> DealFrom(List<Card> cards, int quantity)
{
    if (quantity > cards.Count)
    {
        throw new InvalidOperationException($"You don't have {quantity} cards left.");
    }
    
    List<Card> dealt = new();
    for (var i = 0; i < quantity; i++)
        dealt.Add(DealOneFrom(cards));

    return dealt;
}

List<Card> DealFromAlternate(List<Card> cards, int quantity)
{   
    var dealt = cards.Take(quantity).ToList();
    cards.RemoveRange(0, quantity);
    return dealt;
}

// insert a card randomly into the list of cards.
void InsertRandomlyInto(List<Card> cards, Card card)
{
    var pos = RNG.Next(0, cards.Count);
    cards.Insert(pos, card);
}

// split the list of cards into two equal(ish) halfs and return both as new lists.
(List<Card>, List<Card>) Split(List<Card> cards)
{
    var splitPoint = cards.Count / 2 ;
    List<Card> a = DealFrom(cards, splitPoint);
    List<Card> b = DealFrom(cards, cards.Count);
    return (a, b);
}
// Bonus:  Implement your Shuffling Algorithm
void Shuffle(List<Card> cards)
{
    // Split `cards` into `a` and `b`
    (var a, var b) = Split(cards);

    while (a.Any() || b.Any())
    {
        var chooseA = RNG.Next(2) == 1;
        // if there are cards AND `a` is not empty...
        if(chooseA && a.Any())
            InsertRandomlyInto(cards, DealOneFrom(a));
        // otherwise, if `b` is not empty...
        else if(b.Any())
            InsertRandomlyInto(cards, DealOneFrom(b));
        else if(!chooseA && !b.Any())
            InsertRandomlyInto(cards, DealOneFrom(a));
    }
}
#endregion // methods