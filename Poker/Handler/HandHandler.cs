using Poker.Enum;
using Poker.Exception;
using Poker.Model;

namespace Poker.Handler;

public class HandHandler : IHandHandler {
    private readonly CardHandler _cardHandler = CardHandler.Instance;
    private readonly TypeHandler _typeHandler = TypeHandler.Instance;

    private HandHandler() {
    }

    public static HandHandler Instance { get; } = new HandHandler();

    public int CompareTwoHands(EHandType type1, EHandType type2, List<int> ranks1, List<int> ranks2) {
        if (type1 != type2) return type1 > type2 ? 1 : -1;

        if (ranks1.Count != ranks2.Count) {
            throw new RankCountNotEqual();
        }

        foreach (var (rank1, rank2) in ranks1.Zip(ranks2, (r1, r2) => (r1, r2))) {
            if (rank1 != rank2) {
                return rank1 > rank2 ? 1 : -1;
            }
        }

        return 0;
    }

    public int CompareTwoHands(Hand hand1, Hand hand2) {
        return CompareTwoHands(hand1.Type, hand2.Type, hand1.Ranks, hand2.Ranks);
    }

    public List<int> GetMaxHands(List<Hand> hands) {
        if (hands.Count == 0) return new List<int>();

        var maxHands = new List<int> { 0 };
        var maxHand = hands[0];

        for (var i = 1; i < hands.Count; i++) {
            var hand = hands[i];
            if (CompareTwoHands(maxHand, hand) < 0) {
                maxHands.Clear();
                maxHands.Add(i);
                maxHand = hand;
            }
            else if (CompareTwoHands(maxHand, hand) == 0) {
                maxHands.Add(i);
            }
        }

        return maxHands;
    }

    public List<List<Card>> GetCombinations(List<Card> cards, int n) {
        if (n <= 0 || cards.Count < n) return [new List<Card>()];

        List<List<Card>> combinations = new List<List<Card>>();
        int count = cards.Count;
        if (n > count) return combinations;

        // Generate all combinations of size n
        for (int i = 0; i < (1 << count); i++) {
            List<Card> combination = new List<Card>();
            for (int j = 0; j < count; j++) {
                if ((i & (1 << j)) != 0) {
                    combination.Add(cards[j]);
                }
            }

            if (combination.Count == n) {
                combinations.Add(combination);
            }
        }

        return combinations;
    }

    public (EHandType type, List<int> ranks) GetTypeAndRanks(List<Card> cards) {
        _cardHandler.SortCardsByNumber(cards);

        // Royal Flush
        if (_typeHandler.IsFlush(cards, out var ranks) &&
            _typeHandler.IsStraight(cards, out ranks) &&
            ranks[0] == 14) {
            return (EHandType.RoyalFlush, ranks);
        }

        // Straight Flush
        if (_typeHandler.IsFlush(cards, out ranks) &&
            _typeHandler.IsStraight(cards, out ranks)) {
            return (EHandType.StraightFlush, ranks);
        }

        // Four of a Kind
        if (_typeHandler.IsFourOfAKind(cards, out ranks)) {
            return (EHandType.FourOfAKind, ranks);
        }

        // Full House
        if (_typeHandler.IsFullHouse(cards, out ranks)) {
            return (EHandType.FullHouse, ranks);
        }

        // Flush
        if (_typeHandler.IsFlush(cards, out ranks)) {
            return (EHandType.Flush, ranks);
        }

        // Straight
        if (_typeHandler.IsStraight(cards, out ranks)) {
            return (EHandType.Straight, ranks);
        }

        // Three of a Kind
        if (_typeHandler.IsThreeOfAKind(cards, out ranks)) {
            return (EHandType.ThreeOfAKind, ranks);
        }

        // Two Pair
        if (_typeHandler.IsTwoPair(cards, out ranks)) {
            return (EHandType.TwoPair, ranks);
        }

        // One Pair
        if (_typeHandler.IsOnePair(cards, out ranks)) {
            return (EHandType.OnePair, ranks);
        }

        // High Card
        return (EHandType.HighCard, ranks);
    }
}