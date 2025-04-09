using Poker.Enum;
using Poker.Handler;
using Poker.Model;

namespace Poker;

public class PokerHandler : IHandler {
    private readonly CardHandler _cardHandler = CardHandler.Instance;

    private readonly HandHandler _handHandler = HandHandler.Instance;

    private PokerHandler() {
    }

    public static PokerHandler Instance { get; } = new();

    public int CompareTwoHands(Hand hand1, Hand hand2) {
        return _handHandler.CompareTwoHands(hand1, hand2);
    }

    public List<int> GetMaxHands(List<Hand> hands) {
        return _handHandler.GetMaxHands(hands);
    }

    public void SortCardsByNumber(List<Card> cards) {
        _cardHandler.SortCardsByNumber(cards);
    }

    public void SortCardsByColor(List<Card> cards) {
        _cardHandler.SortCardsByColor(cards);
    }

    public Deck GetDeck() {
        return new Deck();
    }

    public Card GetCard(EColor color, ENumber number) {
        return new Card(color, number);
    }

    public Hand GetHand(List<Card> cards) {
        return new Hand(cards);
    }
}