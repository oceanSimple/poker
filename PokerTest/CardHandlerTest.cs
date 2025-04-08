using Poker.Enum;
using Poker.Handler;
using Poker.Model;

namespace PokerTest;

public class CardHandlerTest {
    private readonly ICardHandler _handler = CardHandler.Instance;

    [Fact]
    public void TestSortCardsByNumber() {
        var cards = new List<Card> {
            new Card(EColor.Spade, ENumber.Two),
            new Card(EColor.Spade, ENumber.Ace),
            new Card(EColor.Diamond, ENumber.Four),
            new Card(EColor.Club, ENumber.Three),
            new Card(EColor.Heart, ENumber.Five),
        };

        _handler.SortCardsByNumber(cards);

        Assert.Equal(
            [
                new Card(EColor.Spade, ENumber.Ace),
                new Card(EColor.Heart, ENumber.Five),
                new Card(EColor.Diamond, ENumber.Four),
                new Card(EColor.Club, ENumber.Three),
                new Card(EColor.Spade, ENumber.Two)
            ],
            cards
        );
    }

    [Fact]
    public void TestSortCardsByColor() {
        var cards = new List<Card> {
            new Card(EColor.Diamond, ENumber.Four),
            new Card(EColor.Spade, ENumber.Two),
            new Card(EColor.Heart, ENumber.Five),
            new Card(EColor.Spade, ENumber.Ace),
            new Card(EColor.Club, ENumber.Three),
        };

        _handler.SortCardsByColor(cards);

        Assert.Equal(
            [
                new Card(EColor.Spade, ENumber.Ace),
                new Card(EColor.Spade, ENumber.Two),
                new Card(EColor.Heart, ENumber.Five),
                new Card(EColor.Diamond, ENumber.Four),
                new Card(EColor.Club, ENumber.Three),
            ],
            cards
        );
    }
}