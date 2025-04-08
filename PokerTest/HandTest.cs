using Poker.Enum;
using Poker.Model;
using Xunit.Abstractions;

namespace PokerTest;

public class HandTest(ITestOutputHelper testOutputHelper) {
    [Fact]
    public void TestHand() {
        // ♠K ♥Q ♠Q ♦J ♣10 ♠9 ♣2
        var cards = new List<Card> {
            new(EColor.Spade, ENumber.King),
            new(EColor.Heart, ENumber.Queen),
            new(EColor.Spade, ENumber.Queen),
            new(EColor.Diamond, ENumber.Jack),
            new(EColor.Club, ENumber.Ten),
            new(EColor.Spade, ENumber.Nine),
            new(EColor.Club, ENumber.Two)
        };

        var hand = new Hand(cards);
        Assert.Equal(EHandType.Straight, hand.Type);

        // ♠A ♠2 ♠3 ♠4 ♠5 ♥A ♣A
        cards = [
            new Card(EColor.Spade, ENumber.Ace),
            new Card(EColor.Spade, ENumber.Two),
            new Card(EColor.Spade, ENumber.Three),
            new Card(EColor.Spade, ENumber.Four),
            new Card(EColor.Spade, ENumber.Five),
            new Card(EColor.Heart, ENumber.Ace),
            new Card(EColor.Club, ENumber.Ace)
        ];
        hand = new Hand(cards);
        Assert.Equal(EHandType.StraightFlush, hand.Type);
    }
}