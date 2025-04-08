using Poker.Model;
using Xunit.Abstractions;

namespace PokerTest;

public class HandTest(ITestOutputHelper testOutputHelper) {
    [Fact]
    public void TestGetCombinations() {
        var deck = new Deck();
        var cards = deck.Draw(7);
        var hand = new Hand();
        var combinations = hand.GetCombinations(cards, 5);

        Assert.Equal(21, combinations.Count);
    }
}