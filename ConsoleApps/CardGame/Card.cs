// ReSharper disable All
namespace CardGame;

public class Card
{
    public Suits Suit { get; set; }
    public Values Value { get; set; }

    public Card(Suits suit, Values value)
    {
        Suit = suit;
        Value = value;
    } 
}

public enum Suits:long
{
    Hearts = '\u2661',
    Diamonds = '\u2b26', 
    Spades = '\u2664',
    Clubs = '\u2667'
}

public enum Values
{
    Ace = 1,
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
    King
}


