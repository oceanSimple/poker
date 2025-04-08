using Poker.Exception;
using Poker.Model;

namespace Poker.Handler;

public class HandHandler : IHandHandler {
    public bool IsFlush(List<Card>? cards, out List<int> ranks) {
        ranks = new List<int>();

        if (cards == null || cards.Count != 5) {
            throw new CardsCounterException("5");
        }

        var firstCardColor = cards[0].Color.Code;
        foreach (var card in cards) {
            if (card.Color.Code != firstCardColor) {
                return false;
            }

            ranks.Add(card.Number.Value);
        }

        return true;
    }

    public bool IsStraight(List<Card> cards, out List<int> ranks) {
        throw new NotImplementedException();
    }

    public bool IsFourOfAKind(List<Card> cards, out List<int> ranks) {
        throw new NotImplementedException();
    }

    public bool IsFullHouse(List<Card> cards, out List<int> ranks) {
        throw new NotImplementedException();
    }

    public bool IsThreeOfAKind(List<Card> cards, out List<int> ranks) {
        throw new NotImplementedException();
    }

    public bool IsTwoPair(List<Card> cards, out List<int> ranks) {
        throw new NotImplementedException();
    }

    public bool IsOnePair(List<Card> cards, out List<int> ranks) {
        throw new NotImplementedException();
    }
}