using Poker.Enum;
using Poker.Exception;
using Poker.Handler;
using Poker.Model;
using Xunit.Abstractions;

namespace PokerTest;

public class TypeHandlerTest(ITestOutputHelper testOutputHelper) {
    private readonly ITypeHandler _handler = TypeHandler.Instance;

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
    }

    [Fact]
    public void TestIsStraight() {
        var cards = new List<Card>();
        List<int> ranks;
        Assert.Throws<CardsCounterException>(() => _handler.IsStraight(cards, out ranks));

        // Test A 5 4 3 2
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Heart, ENumber.Five));
        cards.Add(new Card(EColor.Diamond, ENumber.Four));
        cards.Add(new Card(EColor.Club, ENumber.Three));
        cards.Add(new Card(EColor.Spade, ENumber.Two));

        Assert.True(_handler.IsStraight(cards, out ranks));
        Assert.Equal(5, ranks.Count);

        // Test with 5 cards in a straight
        cards.Clear();
        cards.Add(new Card(EColor.Spade, ENumber.Jack));
        cards.Add(new Card(EColor.Heart, ENumber.Ten));
        cards.Add(new Card(EColor.Diamond, ENumber.Nine));
        cards.Add(new Card(EColor.Club, ENumber.Eight));
        cards.Add(new Card(EColor.Spade, ENumber.Seven));

        Assert.True(_handler.IsStraight(cards, out ranks));
        Assert.Equal(5, ranks.Count);

        // Test with 5 cards not in a straight
        cards.Clear();
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Heart, ENumber.Five));
        cards.Add(new Card(EColor.Diamond, ENumber.Four));
        cards.Add(new Card(EColor.Club, ENumber.Three));
        cards.Add(new Card(EColor.Spade, ENumber.Six));
        Assert.False(_handler.IsStraight(cards, out ranks));
        Assert.Empty(ranks);
    }

    [Fact]
    public void TestIsFourOfAKind() {
        var cards = new List<Card>();
        List<int> ranks;
        Assert.Throws<CardsCounterException>(() => _handler.IsFourOfAKind(cards, out ranks));

        // Test with 4 of a kind
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Heart, ENumber.Ace));
        cards.Add(new Card(EColor.Diamond, ENumber.Ace));
        cards.Add(new Card(EColor.Club, ENumber.Ace));
        cards.Add(new Card(EColor.Spade, ENumber.Two));

        Assert.True(_handler.IsFourOfAKind(cards, out ranks));
        Assert.Equal(2, ranks.Count);
    }

    [Fact]
    public void TestIsFullHouse() {
        var cards = new List<Card>();
        List<int> ranks;
        Assert.Throws<CardsCounterException>(() => _handler.IsFullHouse(cards, out ranks));

        // Test with a full house
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Heart, ENumber.Ace));
        cards.Add(new Card(EColor.Diamond, ENumber.Ace));
        cards.Add(new Card(EColor.Club, ENumber.Two));
        cards.Add(new Card(EColor.Spade, ENumber.Two));

        Assert.True(_handler.IsFullHouse(cards, out ranks));
        Assert.Equal(2, ranks.Count);

        cards.Clear();
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Heart, ENumber.Ace));
        cards.Add(new Card(EColor.Diamond, ENumber.Ace));
        cards.Add(new Card(EColor.Spade, ENumber.Seven));
        cards.Add(new Card(EColor.Club, ENumber.Two));


        Assert.False(_handler.IsFullHouse(cards, out ranks));
    }

    [Fact]
    public void TestIsThreeOfAKind() {
        var cards = new List<Card>();
        List<int> ranks;
        Assert.Throws<CardsCounterException>(() => _handler.IsThreeOfAKind(cards, out ranks));

        // Test with 3 of a kind
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Heart, ENumber.Ace));
        cards.Add(new Card(EColor.Diamond, ENumber.Ace));
        cards.Add(new Card(EColor.Spade, ENumber.Seven));
        cards.Add(new Card(EColor.Club, ENumber.Two));

        Assert.True(_handler.IsThreeOfAKind(cards, out ranks));
        Assert.Equal(3, ranks.Count);
        testOutputHelper.WriteLine(string.Join(",", ranks));
    }

    [Fact]
    public void TestIsTwoPair() {
        var cards = new List<Card>();
        List<int> ranks;
        Assert.Throws<CardsCounterException>(() => _handler.IsTwoPair(cards, out ranks));

        // Test with 2 pairs
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Heart, ENumber.Ace));
        cards.Add(new Card(EColor.Club, ENumber.Seven));
        cards.Add(new Card(EColor.Diamond, ENumber.Two));
        cards.Add(new Card(EColor.Spade, ENumber.Two));

        Assert.True(_handler.IsTwoPair(cards, out ranks));
        Assert.Equal(3, ranks.Count);
    }

    [Fact]
    public void TestIsPair() {
        var cards = new List<Card>();
        List<int> ranks;
        Assert.Throws<CardsCounterException>(() => _handler.IsTwoPair(cards, out ranks));

        // Test with a pair
        cards.Add(new Card(EColor.Spade, ENumber.Ace));
        cards.Add(new Card(EColor.Heart, ENumber.Ace));
        cards.Add(new Card(EColor.Diamond, ENumber.Seven));
        cards.Add(new Card(EColor.Spade, ENumber.Three));
        cards.Add(new Card(EColor.Club, ENumber.Two));

        Assert.True(_handler.IsOnePair(cards, out ranks));
        Assert.Equal(4, ranks.Count);
    }
}