using Poker.Enum;
using Poker.Model;

namespace Poker;

public interface IHandler {
    /// <summary>
    ///     Compare two hands. <br />
    /// </summary>
    /// <returns>
    ///     1: hand1 > hand2 <br />
    ///     0: hand1 = hand2 <br />
    ///     -1: hand1 less than  hand2  <br />
    /// </returns>
    int CompareTwoHands(Hand hand1, Hand hand2);

    /// <summary>
    ///     Get the max hands' index from the given hands. <br />
    /// </summary>
    /// <returns>
    ///     A list of max hands' index from the given hands. <br />
    /// </returns>
    List<int> GetMaxHands(List<Hand> hands);

    /// <summary>
    ///     Sorts the cards by their number in descending order.
    /// </summary>
    /// <param name="cards">The cards that need to be sorted</param>
    void SortCardsByNumber(List<Card> cards);

    /// <summary>
    ///     Sorts the cards by their color in ascending order. <br />
    ///     If two cards have the same color, they are sorted by their number in descending order.
    /// </summary>
    /// <param name="cards">The cards that need to be sorted</param>
    void SortCardsByColor(List<Card> cards);

    /// <summary>
    ///     Get the deck of cards. <br />
    /// </summary>
    /// <returns></returns>
    Deck GetDeck();

    /// <summary>
    ///     Get the card by its color and number. <br />
    /// </summary>
    /// <returns></returns>
    Card GetCard(EColor color, ENumber number);

    /// <summary>
    ///     Get the hand from the given cards. <br />
    /// </summary>
    /// <returns></returns>
    Hand GetHand(List<Card> cards);
}