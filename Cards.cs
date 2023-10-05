namespace CS7_Alg_Cards;

public record struct Card(Suit Suit, Value Value)
{
    public override string ToString() => $"{Suit}{Value}";
}

public struct Suit
{
    public static readonly Suit Spades = new('\u2660');
    public static readonly Suit Hearts = new('\u2661');
    public static readonly Suit Clubs = new('\u2663');
    public static readonly Suit Diamonds = new('\u2662');

    public static readonly Suit[] AllSuits =
    {
        Spades, Hearts, Clubs, Diamonds
    };
    
    private char _suit;
    private Suit(char s) => _suit = s;

    public override string ToString() => $"{_suit}";
}

public struct Value
{

    public static readonly Value AceLow = new(1);
    public static readonly Value Two = new(2);
    public static readonly Value Three = new(3);
    public static readonly Value Four = new(4);
    public static readonly Value Five = new(5);
    public static readonly Value Six = new(6);
    public static readonly Value Seven = new(7);
    public static readonly Value Eight = new(8);
    public static readonly Value Nine = new(9);
    public static readonly Value Ten = new(10);
    public static readonly Value Jack = new(11);
    public static readonly Value Queen = new(12);
    public static readonly Value King = new(13);
    public static readonly Value AceHigh = new(14);

    public static Value[] AllValues =
    {
        AceLow,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        AceHigh
    };

private static readonly string[] valuesAsStrings =
    {
        "A",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "J",
        "Q",
        "K",
        "A"
    };
    
    private int _value;

    private Value(int val) => _value = val;

    public override string ToString() => valuesAsStrings[_value - 1];
}