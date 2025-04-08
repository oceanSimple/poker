using Poker.Exception;

namespace Poker.Model;

using Enum;

/// <summary>
///     The deck of cards, which contains 52 cards. <br/>
///     Including sort, shuffle, draw, and print functions. <br/>
/// </summary>
public class Deck {
    private readonly List<Card> _deck;
    public int Count => _deck.Count;

    /// <summary>
    ///     Create a new deck of 52 cards. <br/>
    ///     Excluding 2 joker cards.
    /// </summary>
    public Deck() {
        _deck = new List<Card>();
        foreach (EColor color in System.Enum.GetValues(typeof(EColor))) {
            foreach (ENumber number in System.Enum.GetValues(typeof(ENumber))) {
                var card = new Card(color, number);
                _deck.Add(card);
            }
        }
    }

    /// <summary>
    ///     Sort the deck by color and number. <br/>
    ///     Sort by the color code and number value, so A is the biggest card.
    /// </summary>
    public void Sort() {
        _deck.Sort((x, y) => {
            int colorComparison = x.Color.CompareTo(y.Color);
            if (colorComparison != 0) {
                return colorComparison;
            }

            return x.Number.CompareTo(y.Number);
        });
    }

    /// <summary>
    ///     Shuffle the deck.
    /// </summary>
    public void Shuffle() {
        var random = new Random();
        for (int i = _deck.Count - 1; i > 0; i--) {
            int j = random.Next(i + 1);
            (_deck[i], _deck[j]) = (_deck[j], _deck[i]);
        }
    }

    /// <summary>
    ///     Draw n cards from the deck. <br/>
    /// </summary>
    /// <param name="n">The number of drawn cards</param>
    /// <returns>
    ///     Drawn cards. <br/>
    ///     If there's no enough cards in the deck, it won't throw exception, but return a blank list
    /// </returns>
    public List<Card> Draw(int n) {
        if (n > _deck.Count) {
            throw new NoEnoughCardsInDeck();
        }

        var drawnCards = _deck.Take(n).ToList();
        _deck.RemoveRange(0, n);
        return drawnCards;
    }

    public override string ToString() {
        var count = 0;
        var result = "";
        foreach (var card in _deck) {
            result += card + " ";
            count++;
            if (count % 13 == 0) {
                result += "\n";
            }
        }

        return result;
    }
}