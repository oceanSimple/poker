using Poker.Enum;
using Poker.Model;

namespace Poker.Handler;

public interface IHandHandler {
    /// <summary>
    ///   According to the given type and ranks, compare two hands. <br/>
    /// </summary>
    /// <returns>
    ///   1: hand1 > hand2 <br/>
    ///   0: hand1 = hand2 <br/>
    ///   -1: hand1 less than  hand2  <br/>
    /// </returns>
    int CompareTwoHands(EHandType type1, EHandType type2, List<int> ranks1, List<int> ranks2);

    /// <summary>
    ///   Compare two hands. <br/>
    /// </summary>
    /// <returns>
    ///   1: hand1 > hand2 <br/>
    ///   0: hand1 = hand2 <br/>
    ///   -1: hand1 less than  hand2  <br/>
    /// </returns>
    int CompareTwoHands(Hand hand1, Hand hand2);

    /// <summary>
    ///   Get the max hands' index from the given hands. <br/>
    /// </summary>
    /// <returns>
    ///    A list of max hands' index from the given hands. <br/>
    /// </returns>
    List<int> GetMaxHands(List<Hand> hands);

    /// <summary>
    ///     Get all combinations of n cards from the given list of cards.
    /// </summary>
    /// <param name="cards">Given list of cards</param>
    /// <param name="n">The number of combination cards</param>
    /// <returns>
    ///     A list of all combinations of n cards from the given list of cards.
    /// </returns>
    List<List<Card>> GetCombinations(List<Card> cards, int n);

    /// <summary>
    ///     According to the cards, determine the type of hand and the ranks. <br/>
    /// </summary>
    /// <returns>
    ///     A tuple containing the type of hand and the ranks. <br/>
    /// </returns>
    (EHandType type, List<int> ranks) GetTypeAndRanks(List<Card> cards);
}