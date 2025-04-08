using Poker.Model;

namespace Poker.Handler;

public interface ICardHandler {
    /// <summary>
    ///   Sorts the cards by their number in descending order.
    /// </summary>
    /// <param name="cards">The cards that need to be sorted</param>
    void SortCardsByNumber(List<Card> cards);

    /// <summary>
    ///    Sorts the cards by their color in ascending order. <br/>
    ///    If two cards have the same color, they are sorted by their number in descending order.
    /// </summary>
    /// <param name="cards">The cards that need to be sorted</param>
    void SortCardsByColor(List<Card> cards);
}