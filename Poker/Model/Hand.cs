using Poker.Enum;
using Poker.Handler;

namespace Poker.Model;

public class Hand {
    private readonly HandHandler _handHandler = HandHandler.Instance;

    // Initial cards
    public readonly List<Card> Cards;

    // Max combination 5 cards for the hand
    public readonly List<Card> MaxCombination;

    // When two hand are the same type, use ranks to compare
    public readonly List<int> Ranks;

    // Hand type, e.g., Straight, Flush, etc.
    public readonly EHandType Type;

    public Hand(List<Card> cards) {
        var maxType = EHandType.None;
        var maxRanks = new List<int>();
        var maxCombination = new List<Card>();

        var combinations = _handHandler.GetCombinations(cards, 5);
        foreach (var combination in combinations) {
            var (type, ranks) = _handHandler.GetTypeAndRanks(combination);
            if (_handHandler.CompareTwoHands(type, maxType, ranks, maxRanks) == 1) {
                maxType = type;
                maxRanks = ranks;
                maxCombination = combination;
            }
        }

        Cards = cards;
        Type = maxType;
        Ranks = maxRanks;
        MaxCombination = maxCombination;
    }

    /// <summary>
    ///     Warning: This constructor is used for testing
    /// </summary>
    public Hand(EHandType type, List<int> ranks) {
        Cards = [];
        Type = type;
        Ranks = ranks;
        MaxCombination = [];
    }

    public override string ToString() {
        return string.Join(" ", MaxCombination);
    }
}