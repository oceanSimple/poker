using Poker.Enum;
using Poker.Exception;
using Poker.Handler;
using Poker.Model;
using Xunit.Abstractions;

namespace PokerTest;

public class HandHandlerTest(ITestOutputHelper testOutputHelper) {
    private readonly HandHandler _handler = new HandHandler();

    [Fact]
    public void TestIsFlush() {
        var cards = new List<Card>();
        List<int> ranks;
        Assert.Throws<CardsCounterException>(() => _handler.IsFlush(cards, out ranks));

        // Test with 5 cards of the same color
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Spade, ENumber.Five));
        cards.Add(new Card(EColor.Spade, ENumber.Four));
        cards.Add(new Card(EColor.Spade, ENumber.Three));
        cards.Add(new Card(EColor.Spade, ENumber.Two));

        Assert.True(_handler.IsFlush(cards, out ranks));
        Assert.Equal(5, ranks.Count);
        testOutputHelper.WriteLine(string.Join(", ", ranks));
    }
}