using Poker.Model;

namespace Poker.Handler;

public class CardHandler : ICardHandler {
    private CardHandler() { }
    
    public static CardHandler Instance { get; } = new CardHandler();

    public void SortCardsByNumber(List<Card> cards) {
        cards.Sort((card1, card2) => card2.Number.Value.CompareTo(card1.Number.Value));
    }

    public void SortCardsByColor(List<Card> cards) {
        cards.Sort((card1, card2) => {
            var colorComparison = card1.Color.Code.CompareTo(card2.Color.Code);
            if (colorComparison != 0) {
                return colorComparison;
            }

            return card2.Number.Value.CompareTo(card1.Number.Value);
        });
    }
}