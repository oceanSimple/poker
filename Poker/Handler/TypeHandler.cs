using Poker.Exception;
using Poker.Model;

namespace Poker.Handler;

public class TypeHandler : ITypeHandler {
    private TypeHandler() {
    }

    public static TypeHandler Instance { get; } = new();

    public bool IsFlush(List<Card> cards, out List<int> ranks) {
        ranks = new List<int>();

        if (cards == null || cards.Count != 5) throw new CardsCounterException("5");

        var firstCardColor = cards[0].Color.Code;
        foreach (var card in cards) {
            if (card.Color.Code != firstCardColor) return false;

            ranks.Add(card.Number.Value);
        }

        return true;
    }

    public bool IsStraight(List<Card> cards, out List<int> ranks) {
        ranks = new List<int>();

        if (cards == null || cards.Count != 5) throw new CardsCounterException("5");

        // Special case for Ace low straight
        // A 5 4 3 2
        if (cards[0].Number.Value == 14 && cards[1].Number.Value == 5)
            if (cards[2].Number.Value == 4 && cards[3].Number.Value == 3 && cards[4].Number.Value == 2) {
                ranks.AddRange(new List<int> { 5, 4, 3, 2, 14 });
                return true;
            }

        for (var i = 0; i < cards.Count - 1; i++) {
            if (cards[i].Number.Value - 1 != cards[i + 1].Number.Value) return false;

            ranks.Add(cards[i].Number.Value);
        }

        ranks.Add(cards[^1].Number.Value);
        return true;
    }

    public bool IsFourOfAKind(List<Card> cards, out List<int> ranks) {
        ranks = new List<int>();

        if (cards == null || cards.Count != 5) throw new CardsCounterException("5");

        var cardGroups = cards.GroupBy(c => c.Number.Value).ToList();
        if (cardGroups.Count == 2 && cardGroups.Any(g => g.Count() == 4)) {
            // Add the card of the four of a kind and the kicker
            ranks.Add(cardGroups.First(g => g.Count() == 4).Key);
            ranks.Add(cardGroups.First(g => g.Count() == 1).Key);
            return true;
        }

        return false;
    }

    public bool IsFullHouse(List<Card> cards, out List<int> ranks) {
        ranks = new List<int>();

        if (cards == null || cards.Count != 5) throw new CardsCounterException("5");

        var cardGroups = cards.GroupBy(c => c.Number.Value).ToList();
        if (cardGroups.Count == 2 &&
            cardGroups.Any(g => g.Count() == 3) &&
            cardGroups.Any(g => g.Count() == 2)) {
            // Add the card of the three of a kind and the pair
            ranks.Add(cardGroups.First(g => g.Count() == 3).Key);
            ranks.Add(cardGroups.First(g => g.Count() == 2).Key);
            return true;
        }

        return false;
    }

    public bool IsThreeOfAKind(List<Card> cards, out List<int> ranks) {
        ranks = new List<int>();

        if (cards == null || cards.Count != 5) throw new CardsCounterException("5");

        var cardGroups = cards.GroupBy(c => c.Number.Value).ToList();
        if (cardGroups.Count == 3 && cardGroups.Any(g => g.Count() == 3)) {
            // Add the card of the three of a kind and the kickers
            ranks.Add(cardGroups.First(g => g.Count() == 3).Key);
            ranks.AddRange(cardGroups.Where(g => g.Count() == 1).Select(g => g.Key));
            return true;
        }

        return false;
    }

    public bool IsTwoPair(List<Card> cards, out List<int> ranks) {
        ranks = new List<int>();

        if (cards == null || cards.Count != 5) throw new CardsCounterException("5");

        var cardGroups = cards.GroupBy(c => c.Number.Value).ToList();
        if (cardGroups.Count == 3 && cardGroups.Any(g => g.Count() == 2)) {
            // Add the two pairs and the kicker
            ranks.AddRange(cardGroups.Where(g => g.Count() == 2).Select(g => g.Key));
            ranks.Add(cardGroups.First(g => g.Count() == 1).Key);
            return true;
        }

        return false;
    }

    public bool IsOnePair(List<Card> cards, out List<int> ranks) {
        ranks = new List<int>();

        if (cards == null || cards.Count != 5) throw new CardsCounterException("5");

        var cardGroups = cards.GroupBy(c => c.Number.Value).ToList();
        if (cardGroups.Count == 4 && cardGroups.Any(g => g.Count() == 2)) {
            // Add the pair and the kickers
            ranks.Add(cardGroups.First(g => g.Count() == 2).Key);
            ranks.AddRange(cardGroups.Where(g => g.Count() == 1).Select(g => g.Key));
            return true;
        }

        return false;
    }
}