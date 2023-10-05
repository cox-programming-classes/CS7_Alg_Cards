/// Let's Write A Card Game!

using CS7_Alg_Cards;

var deck = new Card[52];
int aceHigh = 1; // change this to 1 for AceHigh!

for(int i = 0; i < 4; i++)
for (int j = 0; j < 13; j++)
    deck[(13 * i) + j] = new(Suit.AllSuits[i], Value.AllValues[j + aceHigh]);

foreach(var card in deck)
    Console.WriteLine(card);
        
