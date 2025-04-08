using Poker.Model;

namespace Poker.Handler;

/// <summary>
///     Interface for handling poker hands, which is used to judge the type of hand. <br/>
/// </summary>
public interface IHandHandler {
    /// <summary>
    ///   Check if the hand is a Flush. <br/>
    /// </summary>
    /// <param name="cards">The cards that need to be judged</param>
    /// <param name="ranks">Out ranks param</param>
    /// <returns>Bool result</returns>
    bool IsFlush(List<Card>? cards, out List<int> ranks);

    /// <summary>
    ///   Check if the hand is a Straight. <br/>
    /// </summary>
    /// <param name="cards">The cards that need to be judged</param>
    /// <param name="ranks">Out ranks param</param>
    /// <returns>Bool result</returns>
    bool IsStraight(List<Card> cards, out List<int> ranks);

    /// <summary>
    ///   Check if the hand is Four of a Kind. <br/>
    /// </summary>
    /// <param name="cards">The cards that need to be judged</param>
    /// <param name="ranks">Out ranks param</param>
    /// <returns>Bool result</returns>
    bool IsFourOfAKind(List<Card> cards, out List<int> ranks);

    /// <summary>
    ///   Check if the hand is a Full House. <br/>
    /// </summary>
    /// <param name="cards">The cards that need to be judged</param>
    /// <param name="ranks">Out ranks param</param>
    /// <returns>Bool result</returns>
    bool IsFullHouse(List<Card> cards, out List<int> ranks);

    /// <summary>
    ///   Check if the hand is Three of a Kind. <br/>
    /// </summary>
    /// <param name="cards">The cards that need to be judged</param>
    /// <param name="ranks">Out ranks param</param>
    /// <returns>Bool result</returns>
    bool IsThreeOfAKind(List<Card> cards, out List<int> ranks);

    /// <summary>
    ///   Check if the hand is Two Pair. <br/>
    /// </summary>
    /// <param name="cards">The cards that need to be judged</param>
    /// <param name="ranks">Out ranks param</param>
    /// <returns>Bool result</returns>
    bool IsTwoPair(List<Card> cards, out List<int> ranks);

    /// <summary>
    ///   Check if the hand is One Pair. <br/>
    /// </summary>
    /// <param name="cards">The cards that need to be judged</param>
    /// <param name="ranks">Out ranks param</param>
    /// <returns>Bool result</returns>
    bool IsOnePair(List<Card> cards, out List<int> ranks);
}