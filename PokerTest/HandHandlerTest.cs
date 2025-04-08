using Poker.Enum;
using Poker.Handler;
using Poker.Model;

namespace PokerTest;

public class HandHandlerTest {
    private readonly HandHandler _handHandler = HandHandler.Instance;

    [Fact]
    public void CompareTwoHandsTest() {
        Assert.Equal(1, _handHandler.CompareTwoHands(
            EHandType.Flush,
            EHandType.Straight,
            [14, 13, 12, 11, 10],
            [14, 13, 12, 11, 10]));

        Assert.Equal(0, _handHandler.CompareTwoHands(
            EHandType.Flush,
            EHandType.Flush,
            [14, 13, 12, 11, 10],
            [14, 13, 12, 11, 10]));

        Assert.Equal(0, _handHandler.CompareTwoHands(
            EHandType.ThreeOfAKind,
            EHandType.ThreeOfAKind,
            [3, 1, 2],
            [3, 1, 2]));
    }

    [Fact]
    public void GetCombinationsTest() {
        var cards = new List<Card> {
            new(EColor.Club, ENumber.Ace),
            new(EColor.Club, ENumber.Two),
            new(EColor.Club, ENumber.Three),
            new(EColor.Club, ENumber.Four),
            new(EColor.Club, ENumber.Five),
            new(EColor.Club, ENumber.Six),
            new(EColor.Club, ENumber.Seven)
        };

        var combinations = _handHandler.GetCombinations(cards, 5);

        Assert.Equal(21, combinations.Count);
    }

    [Fact]
    public void GetTypeAndRanksTest() {
        // ♠A ♠2 ♠3 ♠4 ♠5
        var cards = new List<Card> {
            new(EColor.Club, ENumber.Ace),
            new(EColor.Club, ENumber.Two),
            new(EColor.Club, ENumber.Three),
            new(EColor.Club, ENumber.Four),
            new(EColor.Club, ENumber.Five)
        };

        var (type, ranks) = _handHandler.GetTypeAndRanks(cards);

        Assert.Equal(EHandType.StraightFlush, type);
        Assert.Equal([5, 4, 3, 2, 14], ranks);

        // ♠10 ♥10 ♣10 ♦10 ♣2
        cards = [
            new Card(EColor.Club, ENumber.Ten),
            new Card(EColor.Heart, ENumber.Ten),
            new Card(EColor.Diamond, ENumber.Ten),
            new Card(EColor.Spade, ENumber.Ten),
            new Card(EColor.Club, ENumber.Two)
        ];
        (type, ranks) = _handHandler.GetTypeAndRanks(cards);
        Assert.Equal(EHandType.FourOfAKind, type);
        Assert.Equal([10, 2], ranks);

        // ♠10 ♥10 ♣10 ♦2 ♣2
        cards = [
            new Card(EColor.Club, ENumber.Ten),
            new Card(EColor.Heart, ENumber.Ten),
            new Card(EColor.Diamond, ENumber.Two),
            new Card(EColor.Spade, ENumber.Two),
            new Card(EColor.Club, ENumber.Two)
        ];
        (type, ranks) = _handHandler.GetTypeAndRanks(cards);
        Assert.Equal(EHandType.FullHouse, type);
        Assert.Equal([2, 10], ranks);

        // ♠10 ♥10 ♣3 ♦3 ♠2
        cards = [
            new Card(EColor.Club, ENumber.Ten),
            new Card(EColor.Heart, ENumber.Ten),
            new Card(EColor.Diamond, ENumber.Three),
            new Card(EColor.Spade, ENumber.Three),
            new Card(EColor.Club, ENumber.Two)
        ];
        (type, ranks) = _handHandler.GetTypeAndRanks(cards);
        Assert.Equal(EHandType.TwoPair, type);
        Assert.Equal([10, 3, 2], ranks);
    }

    [Fact]
    public void CompareTowHandsTest2() {
        var hand1 = new Hand(EHandType.Flush, [14, 13, 12, 11, 10]);
        var hand2 = new Hand(EHandType.Straight, [14, 13, 12, 11, 10]);
        Assert.Equal(1, _handHandler.CompareTwoHands(hand1, hand2));
    }

    [Fact]
    public void GetMaxHandsTest() {
        var hand1 = new Hand(EHandType.Flush, [14, 13, 12, 11, 10]);
        var hand2 = new Hand(EHandType.Straight, [14, 13, 12, 11, 10]);
        var hand3 = new Hand(EHandType.ThreeOfAKind, [14, 13, 12]);
        var hand4 = new Hand(EHandType.ThreeOfAKind, [14, 13, 12]);
        var hand5 = new Hand(EHandType.Flush, [14, 13, 12, 11, 10]);

        var hands = new List<Hand> { hand1, hand2, hand3, hand4, hand5 };
        var maxHands = _handHandler.GetMaxHands(hands);

        Assert.Equal(2, maxHands.Count);
        Assert.Equal([0, 4], maxHands);
    }
}